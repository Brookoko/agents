using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scenes.Scripts;
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

    private void Start()
    {
        for (var i = 0; i < amount; i++)
        {
            var random = Random.insideUnitCircle * spawnRadius;
            var position = new Vector3(random.x, 1, random.y);
            var agent = Instantiate(agentPrefab, position, Random.rotation, transform);
            agent.Construct(boidsProvider);
            boidsProvider.Add(agent);
        }
    }
}