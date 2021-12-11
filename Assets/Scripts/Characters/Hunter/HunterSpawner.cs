namespace Victor.Agents.Characters.Hunters
{
    using UnityEngine;
    using Input;
    using CharacterController = CharacterController;

    public class HunterSpawner : MonoBehaviour
    {
        [SerializeField]
        private Hunter hunter;

        private IInputProvider inputProvider;

        public void Construct(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }

        public Hunter Create(Transform spawnPoint)
        {
            var instance = Instantiate(hunter, spawnPoint, false);
            var controller = instance.GetComponent<CharacterController>();
            controller.Construct(inputProvider);
            return instance;
        }
    }
}
