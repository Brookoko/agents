namespace Victor.Agents.Characters
{
    using Scenes.Scripts;
    using UnityEngine;

    public class CharacterAttacker : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        public void Attack(Vector3 direction)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.AddForce(direction);
        }
    }
}
