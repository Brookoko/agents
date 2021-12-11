namespace Victor.Agents.Characters
{
    using UnityEngine;

    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rb;

        [SerializeField, Range(0f, 100f)]
        private float maxSpeed = 10f;

        [SerializeField, Range(0f, 100f)]
        private float maxAcceleration = 15f;

        private Vector3 velocity;
        private Vector3 lookDirection;
        private float desireNormalizedMove;

        private void Awake()
        {
            lookDirection = transform.forward;
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Move(Vector3 direction)
        {
            desireNormalizedMove = direction.magnitude;
            lookDirection = desireNormalizedMove == 0 ? transform.forward : direction;
        }

        public void Stop()
        {
            Move(Vector3.zero);
            rb.velocity = Vector3.zero;
            enabled = false;
        }

        private void FixedUpdate()
        {
            velocity = rb.velocity;
            UpdateMovement();
            rb.velocity = velocity;
        }

        private void UpdateMovement()
        {
            var maxChange = maxAcceleration * Time.fixedDeltaTime;
            var desireVelocity = lookDirection * (desireNormalizedMove * maxSpeed);
            velocity.x = Mathf.MoveTowards(velocity.x, desireVelocity.x, maxChange);
            velocity.z = Mathf.MoveTowards(velocity.z, desireVelocity.z, maxChange);
        }
    }
}
