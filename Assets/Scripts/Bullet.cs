namespace Scenes.Scripts
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;

        [SerializeField]
        private float forceAmount = 100;

        [SerializeField]
        private float destroyTime = 5;

        private void Start()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }

        public void AddForce(Vector3 direction)
        {
            rigidbody.AddForce(direction.normalized * forceAmount);
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}