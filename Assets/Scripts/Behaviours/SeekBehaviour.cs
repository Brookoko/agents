namespace Scenes.Behaviours
{
    using UnityEngine;
    using Scripts;

    public class SeekBehaviour : AgentBehaviour
    {
        [SerializeField] [Range(0, 15)]
        private float seekRadiusSqr;

        public Vector2 Target { get; set; }


        public override Vector2 GetDesiredVelocity(Agent agent)
        {
            Debug.DrawRay(transform.position + Vector3.up * 0.75f,
                GetDesiredVelocity(agent, Target).normalized.ToXZVector3(), Color.grey);
            return GetDesiredVelocity(agent, Target);
        }

        public Vector2 GetDesiredVelocity(Agent agent, Vector2 position)
        {
            var agentPosition = agent.transform.position.ToXZVector2();

            var direction = position - agentPosition;
            var magnitude = direction.sqrMagnitude;
            var k = Mathf.Clamp01(magnitude / seekRadiusSqr);
            return k * agent.velocityLimit * direction.normalized;
        }
    }
}