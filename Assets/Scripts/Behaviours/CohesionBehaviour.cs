namespace Scenes.Behaviours
{
    using UnityEngine;
    using Scripts;

    public class CohesionBehaviour : FlockingBehaviour
    {
        [SerializeField]
        private SeekBehaviour seek;
        
        [SerializeField]

        private float cohesionRadiusSqr;

        public override Vector2 GetDesiredVelocity(Agent agent)
        {
            var result = Vector2.zero;
            var count = 0;
            var agentPosition = agent.transform.position.ToXZVector2();
            foreach (var target in TargetsPositions)
            {
                var distance = (target - agentPosition).sqrMagnitude;
                if (distance < cohesionRadiusSqr)
                {
                    result += target;
                    count++;
                }
            }

            if (count == 0) return ZeroDesireVelocity(agent);

            result /= count;
            Debug.DrawLine(agentPosition.ToXZVector3(), result.ToXZVector3(), Color.red, 0.03f);
            return seek.GetDesiredVelocity(agent, result);
        }
    }
}