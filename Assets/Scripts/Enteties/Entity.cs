namespace Victor.Agents.Enteties
{
    using System;
    using UnityEngine;

    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        public int health = 1;

        [SerializeField]
        public DamageType immuneTo;

        public event Action<Hit> OnDeath;
        public event Action<Hit> OnHit;

        public int MaxHealth => health;

        public int Health { get; private set; }

        public bool IsDead { get; private set; }

        private int stepsSinceLastHit;

        private void Awake()
        {
            Health = MaxHealth;
        }

        public bool TryTakeHit(Hit hit)
        {
            if (CanTakeHit(hit))
            {
                TakeHit(hit);
                return true;
            }
            return false;
        }

        public bool CanTakeHit(Hit hit)
        {
            return !IsDead &&
                   (immuneTo & hit.damageType) == 0 &&
                   stepsSinceLastHit > 5;
        }

        public void TakeHit(Hit hit)
        {
            Health = Mathf.Max(0, Health - hit.damage);
            stepsSinceLastHit = 0;
            OnHit?.Invoke(hit);
            if (Health == 0)
            {
                Die(hit);
            }
        }

        protected virtual void Die(Hit hit)
        {
            IsDead = true;
            OnDeath?.Invoke(hit);
        }

        private void Update()
        {
            stepsSinceLastHit++;
        }
    }
}
