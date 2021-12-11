namespace Scenes.Scripts
{
    using System;
    using UnityEngine;

    public class Hunter : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private LayerMask planeLayer;

        private Camera camera;

        private void Start()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Input.mousePosition;
                var ray = camera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out var hit, 100, planeLayer))
                {
                    var direction = transform.position - hit.point;
                    ShootIn(direction);
                }
            }
        }

        private void ShootIn(Vector3 direction)
        {
            direction.y = 0;
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.AddForce(-direction);
        }
    }
}