using Scenes.Scripts;

namespace Scenes.Behaviours
{
    using UnityEngine;

    public class SeparationBehaviour : FlockingBehaviour
    {
        [SerializeField]
        private float separationDistanceSqr;

        [SerializeField]
        private AnimationCurve ease;

        private float positionSubtractionSqrMagnitude;
        private Vector2 positionSubtraction;

        public override Vector2 GetDesiredVelocity(Agent agent)
        {
            var result = Vector2.zero;
            var count = 0;

            var agentPosition = agent.transform.position.ToXZVector2();

            foreach (var target in TargetsPositions)
            {
                positionSubtraction = agentPosition - target;
                positionSubtractionSqrMagnitude = positionSubtraction.sqrMagnitude;

                if (IsVisible())
                {
                    var value = ease.Evaluate(positionSubtractionSqrMagnitude / separationDistanceSqr);
                    var direction = positionSubtraction.normalized * value;
                    result += direction;
                    count++;
                }
            }

            if (count == 0) return ZeroDesireVelocity(agent);

            result /= count;

            Debug.DrawRay(agentPosition.ToXZVector3() + Vector3.up, result.ToXZVector3(), Color.magenta, 0.03f);

            return result * agent.velocityLimit;
        }

        private bool IsVisible()
        {
            return positionSubtractionSqrMagnitude < separationDistanceSqr;
        }
    }
}