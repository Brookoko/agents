namespace Victor.Agents.Areas
{
    using Cameras;
    using UnityEngine;
    using Characters.Hunters;

    public class Area : MonoBehaviour
    {
        [SerializeField]
        private AreaBounds areaBounds;

        [SerializeField]
        private AnimalSpawner[] spawners;

        [SerializeField]
        private Transform playerSpawnPoint;

        private Hunter hunter;
        private GameCamerasController gameCamerasController;

        public void Construct(HunterSpawner hunterSpawner, GameCamerasController gameCamerasController)
        {
            hunter = hunterSpawner.Create(playerSpawnPoint);
            this.gameCamerasController = gameCamerasController;
        }

        public void Init()
        {
            CreateBounds();
            SpawnAnimals();
            hunter.Init();
            gameCamerasController.CurrentCamera.LookAt(hunter.transform);
        }

        private void CreateBounds()
        {
            areaBounds.CreateBounds();
        }

        private void SpawnAnimals()
        {
            foreach (var spawner in spawners)
            {
                spawner.Spawn();
            }
        }
    }
}
