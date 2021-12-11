namespace Scenes.Behaviours
{
    using UnityEngine;

    public class CohesionBehaviour : FlockingBehaviour
    {
        [SerializeField]
        [Range(0, 15)]
        private float cohesionRadius;

        [SerializeField]
        private SeekBehaviour seek;

        public override Vector3 GetDesiredVelocity(Agent agent)
        {
            var result = Vector3.zero;
            var count = 0;

            foreach (var target in FilteredTargets(agent))
            {
                var distance = (target.transform.position - agent.transform.position).sqrMagnitude;
                if (distance < cohesionRadius * cohesionRadius)
                {
                    result += target.transform.position;
                    count++;
                }
            }

            if (count == 0) return ZeroDesireVelocity(agent);

            result /= count;
            Debug.DrawLine(agent.transform.position, result, Color.green, 0.03f);
            return seek.GetDesiredVelocity(agent, result);
        }
    }
}