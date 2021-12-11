namespace Victor.Agents.Characters
{
    using UnityEngine;

    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float rotationSpeed;

        private Quaternion lookRotation;

        public Vector3 Forward => transform.forward;

        private void Awake()
        {
            lookRotation = Quaternion.LookRotation(transform.forward);
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Look(Vector3 lookDirection)
        {
            lookDirection = lookDirection.sqrMagnitude == 0 ? transform.forward : lookDirection;
            lookRotation = Quaternion.LookRotation(lookDirection);
        }

        public void Stop()
        {
            Look(Vector3.zero);
            enabled = false;
        }

        private void Update()
        {
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            var maxChange = rotationSpeed * Mathf.Deg2Rad * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, maxChange);
        }
    }
}
