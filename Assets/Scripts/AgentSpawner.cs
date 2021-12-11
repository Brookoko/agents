using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField]
    private Agent agentPrefab;

    [SerializeField]
    private int amount = 100;

    [SerializeField]
    private float spawnRadius = 10;

    private List<Agent> agents = new List<Agent>();

    private void Start()
    {
        for (var i = 0; i < amount; i++)
        {
            var random = Random.insideUnitCircle * spawnRadius;
            var position = new Vector3(random.x, 0, random.y);
            var agent = Instantiate(agentPrefab, position, Random.rotation, transform);
            agents.Add(agent);
        }

        foreach (var agent in agents)
        {
            var otherAgents = agents.ToList();
            otherAgents.Remove(agent);
            agent.Agents = otherAgents;
        }
    }
}
