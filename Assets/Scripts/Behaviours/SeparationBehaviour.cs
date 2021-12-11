namespace Scenes.Behaviours
{
    using UnityEngine;

    public class SeparationBehaviour : FlockingBehaviour
    {
        [SerializeField]
        [Range(0, 10)]
        private float separationDistance;

        public override Vector3 GetDesiredVelocity(Agent agent)
        {
            var result = Vector3.zero;
            var count = 0;
            foreach (var target in Targets)
            {
                if (IsVisible(agent, target))
                {
                    var direction = agent.transform.position - target.transform.position;
                    result += direction.normalized;
                    count++;
                    Debug.DrawRay(agent.transform.position, direction.normalized * 10, Color.red);
                }
            }

            if (count == 0) return ZeroDesireVelocity(agent);

            result /= count;
            return result.normalized * agent.VelocityLimit;
        }

        private bool IsVisible(Agent agent, Agent target)
        {
            var distance = (agent.transform.position - target.transform.position).sqrMagnitude;
            return distance < separationDistance * separationDistance;
        }
    }
}