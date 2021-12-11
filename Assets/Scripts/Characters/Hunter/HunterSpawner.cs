namespace Victor.Agents.Characters.Hunters
{
    using Areas;
    using UnityEngine;
    using Input;
    using Scenes.Scripts;
    using CharacterController = CharacterController;

    public class HunterSpawner : MonoBehaviour
    {
        [SerializeField]
        private Hunter hunter;
        
        [SerializeField]
        private EntityProvider entityProvider;

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
            instance.Entity.OnDeath += _ => OnDeath(instance);
            entityProvider.entities.Add(instance.Entity);
            return instance;
        }

        private void OnDeath(Hunter hunterInstance)
        {
            hunterInstance.Stop();
            RespawnOnRandomPosition(hunterInstance);
            hunterInstance.Entity.Reset();
            hunterInstance.Init();
        }

        private void RespawnOnRandomPosition(Hunter hunterInstance)
        {
            var point = area.Bounds.GetRandomPoint();
            hunterInstance.transform.position = point;
        }
    }
}
