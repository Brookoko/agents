namespace Victor.Agents.Characters
{
    using Input;
    using UnityEngine;

    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        [SerializeField]
        private CharacterInput characterInput;

        private void Awake()
        {
            characterInput.OnMove += character.Move;
            characterInput.OnRotate += character.Look;
            characterInput.OnFire += character.Fire;
        }

        public void Construct(IInputProvider inputProvider)
        {
            characterInput.Construct(inputProvider);
        }
    }
}
