namespace Victor.Agents.Areas
{
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

        public void Construct(HunterSpawner hunterSpawner)
        {
            hunter = hunterSpawner.Create(playerSpawnPoint);
        }

        public void Init()
        {
            CreateBounds();
            SpawnAnimals();
            hunter.Init();
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
