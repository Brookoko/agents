namespace Scenes.Behaviours
{
    using System.Collections.Generic;
    using System.Linq;
    using Scripts;
    using UnityEngine;

    public abstract class AgentBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(0, 100)]
        public float weight = 1f;

        [SerializeField]
        private AgentType agentTypes;

        [SerializeField]
        public bool isActive = true;

        protected IEnumerable<Vector2> TargetsPositions => targets
            .Where(t => (t.Type & agentTypes) != 0)
            .Select(t => t.transform.position.ToXZVector2());

        public List<Agent> targets { get; set; } = new List<Agent>();

        public abstract Vector2 GetDesiredVelocity(Agent agent);

        protected Vector2 ZeroDesireVelocity(Agent agent)
        {
            return agent.Velocity / weight;
        }
    }
}