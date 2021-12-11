namespace Scenes.Behaviours
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class AgentBehaviour : MonoBehaviour
    {
        [SerializeField]
        [Range(0,6)]
        private float weight = 1f;
        
        public float Weight => weight;
        
        public List<Agent> Targets { get; set; } = new List<Agent>();

        public abstract Vector3 GetDesiredVelocity(Agent agent);

        protected Vector3 ZeroDesireVelocity(Agent agent)
        {
            return agent.Velocity / Weight;
        }
    }
}