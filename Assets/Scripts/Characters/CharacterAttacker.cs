namespace Victor.Agents.Characters
{
    using Enteties;
    using UnityEngine;

    public class CharacterAttacker : MonoBehaviour
    {
        [SerializeField]
        private int damage;

        [SerializeField]
        private float speed;

        [SerializeField]
        private Transform shootPoint;

        [SerializeField]
        private Bullet bulletPrefab;

        public void Attack(Vector3 direction)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.Init(damage, speed);
            bullet.Fly(direction);
        }
    }
}
