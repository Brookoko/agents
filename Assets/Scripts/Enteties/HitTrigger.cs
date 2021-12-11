namespace Victor.Agents.Enteties
{
    using UnityEngine;

    public class HitTrigger : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        [SerializeField]
        private DamageType damageType;

        private void OnTriggerEnter(Collider collider)
        {
            var rb = collider.attachedRigidbody;
            if (rb)
            {
                var entity = rb.GetComponent<Entity>();
                entity?.TryTakeHit(CreateHit());
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
