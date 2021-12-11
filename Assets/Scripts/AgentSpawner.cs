namespace Victor.Agents
{
    using Areas;
    using Enteties;
    using Scenes.Scripts;
    using UnityEditor.VersionControl;
    using UnityEngine;

    public class AgentSpawner : MonoBehaviour
    {
        [SerializeField]
        private Agent agentPrefab;

        [SerializeField]
        private int amount = 100;

        [SerializeField]
        private float spawnRadius = 10;

        [SerializeField]
        private BoidsProvider boidsProvider;

        [SerializeField]
        private EntityProvider entityProvider;

        [SerializeField]
        private Area area;

        private void Start()
        {
            for (var i = 0; i < amount; i++)
            {
                var random = Random.insideUnitCircle * spawnRadius;
                var position = new Vector3(random.x, 0, random.y);
                var agent = Instantiate(agentPrefab, position, Random.rotation, transform);

                agent.Construct(boidsProvider);
                boidsProvider.Add(agent);
                SetupEntity(agent);
            }
        }

        private void SetupEntity(Agent agent)
        {
            var entity = agent.GetComponent<Entity>();
            entityProvider.entities.Add(entity);
            entity.OnDeath += _ => OnDeath(agent);
        }

        private void OnDeath(Agent agent)
        {
            var point = area.Bounds.GetRandomPoint();
            agent.transform.position = point;
        }
    }
}