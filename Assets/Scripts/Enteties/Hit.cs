namespace Victor.Agents.Enteties
{
    using System;

    public class Hit
    {
        public int damage;
        public float speed;
        public DamageType damageType;
    }

    [Flags]
    public enum DamageType
    {
        Normal = 1 << 0,
        Collision = 1 << 1,
    }
}
