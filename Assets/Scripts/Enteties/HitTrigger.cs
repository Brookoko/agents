namespace Victor.Agents.Enteties
{
    using System;
    using UnityEngine;

    public class HitTrigger : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        [SerializeField]
        private DamageType damageType;

        public event Action OnKill;

        private void OnTriggerEnter(Collider collider)
        {
            var rb = collider.attachedRigidbody;
            if (rb)
            {
                var entity = rb.GetComponent<Entity>();
                if (entity && entity.TryTakeHit(CreateHit()))
                {
                    OnKill?.Invoke();
                }
            }
        }

        private Hit CreateHit()
        {
            return new Hit()
            {
                damage = damage,
                damageType = damageType,
                speed = 0
            };
        }
    }
}
