namespace Scenes.Behaviours
{
    using UnityEngine;

    public class SeekBehaviour : AgentBehaviour
    {
        [SerializeField]
        [Range(0, 15)]
        private float seekRadius;
        
        public Transform Target { get; set; }
        
        public override Vector3 GetDesiredVelocity(Agent agent)
        {
            return !Target ? ZeroDesireVelocity(agent) : GetDesiredVelocity(agent, Target.position);
        }

        public Vector3 GetDesiredVelocity(Agent agent, Vector3 position)
        {
            var direction = position - agent.transform.position;
            var magnitude = direction.sqrMagnitude;

            var k = Mathf.Clamp01(magnitude / (seekRadius * seekRadius));
            return k * agent.VelocityLimit * direction.normalized;
        }
    }
}