namespace Victor.Agents.Enteties
{
    using System.Collections;
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private DamageType damageType;

        [SerializeField]
        private float maxLifeTime;

        [SerializeField]
        private LayerMask hitMask;

        private int damage;
        private float speed;

        public void Init(int damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }

        public void Fly(Vector3 direction)
        {
            transform.forward = direction;
            StartCoroutine(Flying());
        }

        private IEnumerator Flying()
        {
            var timer = 0f;
            while (true)
            {
                yield return new WaitForFixedUpdate();
                timer += Time.fixedDeltaTime;
                if (timer >= maxLifeTime || HasAttacked())
                {
                    Stop();
                }
                Move();
            }
        }

        private bool HasAttacked()
        {
            var pos = transform.position;
            var distance = speed * Time.fixedDeltaTime;
            if (Physics.Raycast(pos, transform.forward, out var raycastHit, distance, hitMask))
            {
                var hittable = raycastHit.rigidbody.GetComponent<IHittable>();
                return hittable?.TryTakeHit(CreateHit()) ?? false;
            }
            return false;
        }

        private Hit CreateHit()
        {
            return new Hit()
            {
                damage = damage,
                damageType = damageType,
                speed = speed
            };
        }

        private void Stop()
        {
            Destroy(gameObject);
        }

        private void Move()
        {
            var change = speed * Time.deltaTime;
            transform.position += transform.forward * change;
        }
    }
}
