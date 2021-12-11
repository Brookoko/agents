namespace Victor.Agents.Enteties
{
    using System;
    using UnityEngine;

    public interface IHittable
    {
        event Action<Hit> OnHit;

        bool TryTakeHit(Hit hit);

        bool CanTakeHit(Hit hit);

        void TakeHit(Hit hit);
    }

    public interface IKillable : IHittable
    {
        event Action<Hit> OnDeath;

        bool IsDead { get; }

        int Health { get; }

        int MaxHealth { get; }
        
        void Die();
    }

    public interface IEntity : IKillable
    {
        Vector2 Position { get; }
    }
}