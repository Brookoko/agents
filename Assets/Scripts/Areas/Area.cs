namespace Scenes.Scripts.Areas
{
    using UnityEngine;

    public class Area : MonoBehaviour
    {
        [SerializeField]
        private AreaBounds areaBounds;

        [SerializeField]
        private AnimalSpawner[] spawners;

        private void Awake()
        {
            CreateBounds();
            SpawnAnimals();
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
