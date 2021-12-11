namespace Scenes.Behaviours
{
    using UnityEngine;

    public class AvoidEdgesBehaviour : AgentBehaviour
    {
        [SerializeField]
        [Range(0, 20)]
        private float avoidDistanceToEdge = 5;

        [SerializeField]
        private LayerMask avoidLayer;

        private readonly RaycastHit[] hits = new RaycastHit[3];
        private readonly RaycastHit[] raycast = new RaycastHit[1];

        public override Vector3 GetDesiredVelocity(Agent agent)
        {
            var pos = agent.transform.position;
            var count = HitsNear(pos);
            if (count == 0) return ZeroDesireVelocity(agent);

            var v = Vector3.zero;
            for (var i = 0; i < count; i++)
            {
                var k = 1 - hits[i].distance / avoidDistanceToEdge;
                var target = hits[i].collider.transform.position;
                target.y = agent.transform.position.y;
                var distance = (target - agent.transform.position).magnitude * 1.1f;
                if (Raycast(agent.transform.position, target, distance) > 0)
                {
                    v += agent.VelocityLimit * k * raycast[0].normal;
                }
            }
            Debug.DrawLine(agent.transform.position, agent.transform.position + v / count, Color.cyan, 0.03f);
            return v / count;
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