namespace Victor.Agents.Characters.Hunters
{
    using Areas;
    using Enteties;
    using UnityEngine;
    using Input;
    using CharacterController = CharacterController;

    public class HunterSpawner : MonoBehaviour
    {
        [SerializeField]
        private Hunter hunter;

        private IInputProvider inputProvider;
        private Area area;

        public void Construct(IInputProvider inputProvider, Area area)
        {
            this.inputProvider = inputProvider;
            this.area = area;
        }

        public Hunter Create(Transform spawnPoint)
        {
            var instance = Instantiate(hunter, spawnPoint, false);
            var controller = instance.GetComponent<CharacterController>();
            controller.Construct(inputProvider);
            hunter.Entity.OnDeath += OnDeath;
            return instance;
        }

        private void OnDeath(Hit hit)
        {
            hunter.Stop();
            RespawnOnRandomPosition();
            hunter.Init();
        }

        private void RespawnOnRandomPosition()
        {
            var point = area.Bounds.GetRandomPoint();
            hunter.transform.position = point;
        }
    }
}
