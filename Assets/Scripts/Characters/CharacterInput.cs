namespace Victor.Agents.Characters
{
    using System;
    using UnityEngine;
    using Input;

    public class CharacterInput : MonoBehaviour
    {
        [SerializeField]
        private LayerMask planeLayer;

        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnRotate;
        public event Action OnFire;

        private IInputProvider inputProvider;
        private Camera cam;
        private Vector3 lookPoint;

        private void Awake()
        {
            cam = Camera.main;
            lookPoint = transform.position;
        }

        public void Construct(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
            BindEvents();
        }

        private void BindEvents()
        {
            inputProvider.OnMove += ProcessMove;
            inputProvider.OnPointerMove += ProcessPointer;
            inputProvider.OnTap += ProcessFire;
        }

        private void ProcessMove(Vector2 movement)
        {
            var characterMovement = new Vector3(movement.x, 0, movement.y);
            OnMove?.Invoke(characterMovement);
        }

        private void ProcessPointer(Vector2 look)
        {
            var ray = cam.ScreenPointToRay(look);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit, 100, planeLayer))
            {
                lookPoint = hit.point;
            }
        }

        private void Update()
        {
            var direction = lookPoint - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            OnRotate?.Invoke(direction);
        }

        private void ProcessFire()
        {
            OnFire?.Invoke();
        }
    }
}
