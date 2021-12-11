namespace Scenes.Behaviours
{
    using System.Collections.Generic;
    using System.Linq;
    using Scripts;
    using UnityEngine;
    using Victor.Agents.Enteties;

    public abstract class AgentBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(0, 100)]
        public float weight = 1f;

        [SerializeField]
        private AgentType agentTypes;

        [SerializeField]
        public bool isActive = true;

        protected IEnumerable<Vector2> TargetsPositions => targets
            .Where(t => (t.type & agentTypes) != 0)
            .Select(t => t.transform.position.ToXZVector2());

        public List<Entity> targets { get; set; } = new List<Entity>();

        public abstract Vector2 GetDesiredVelocity(Agent agent);

        protected Vector2 ZeroDesireVelocity(Agent agent)
        {
            return agent.Velocity / weight;
        }
    }
}