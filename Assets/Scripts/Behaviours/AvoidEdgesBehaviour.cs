namespace Scenes.Behaviours
{
    using Scripts;
    using UnityEngine;

    public class AvoidEdgesBehaviour : AgentBehaviour
    {
        [SerializeField]
        private LayerMask avoidLayer;

        [SerializeField]
        private float avoidDistanceToEdge;

        private readonly RaycastHit[] hits = new RaycastHit[3];
        private readonly RaycastHit[] raycast = new RaycastHit[1];
        public override Vector2 GetDesiredVelocity(Agent agent)
        {
            var agentPosition = agent.transform.position;

            var count = HitsNear(agentPosition);
            if (count == 0) return ZeroDesireVelocity(agent);

            var v = Vector3.zero;
            for (var i = 0; i < count; i++)
            {
                var k = 1 - hits[i].distance / avoidDistanceToEdge;
                var target = hits[i].collider.transform.position;
                target.y = agent.transform.position.y;
                var distance = (target - agentPosition).magnitude * 1.1f;
                if (Raycast(agentPosition, target, distance) > 0)
                {
                    v += agent.velocityLimit * k * raycast[0].normal;
                }
            }

            Debug.DrawLine(agentPosition, agentPosition + v / count, Color.cyan, 0.03f);
            return v.ToXZVector2() / count;
        }

        private int HitsNear(Vector3 origin)
        {
            return Physics.SphereCastNonAlloc(origin, avoidDistanceToEdge, Vector3.forward, hits, 0f, avoidLayer);
        }

        private int Raycast(Vector3 origin, Vector3 target, float distance)
        {
            var direction = (target - origin).normalized;
            return Physics.RaycastNonAlloc(origin, direction, raycast, distance);
        }
    }
}