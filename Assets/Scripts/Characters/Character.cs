namespace Victor.Agents.Characters
{
    using Enteties;
    using UnityEngine;

    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterMovement characterMovement;

        [SerializeField]
        private CharacterRotation characterRotation;

        [SerializeField]
        private CharacterAttacker characterAttacker;

        [field: SerializeField]
        public Entity Entity { get; private set; }

        public void Init()
        {
            characterMovement.Enable();
            characterRotation.Enable();
        }

        public void Move(Vector3 movement)
        {
            characterMovement.Move(movement);
        }

        public void Look(Vector3 look)
        {
            characterRotation.Look(look);
        }

        public void Fire()
        {
            characterAttacker.Attack(characterRotation.Forward);
        }

        public void Stop()
        {
            characterMovement.Stop();
            characterRotation.Stop();
        }
    }
}
