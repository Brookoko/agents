namespace Scenes.Behaviours
{
    using UnityEngine;

    public class WanderBehaviour : AgentBehaviour
    {
        [SerializeField]
        [Range(1, 15)]
        private float aheadDistance;

        [SerializeField]
        private SeekBehaviour seek;

        [SerializeField]
        [Range(10, 120)]
        private float randomAngle = 45;

        [SerializeField]
        [Range(0, 200)]
        private int repeatFrame = 10;
        
        private int count;
        private Vector3 wanderPosition;
        
        public override Vector3 GetDesiredVelocity(Agent agent)
        {
            Debug.DrawRay(agent.transform.position, agent.transform.forward * 10, Color.cyan);
            if (count > 0)
            {
                count--;
                return seek.GetDesiredVelocity(agent, wanderPosition);
            }
            var pos = agent.transform.position;
            var forward = Quaternion.AngleAxis((Random.value - 0.5f) * 2 * randomAngle, agent.transform.up) * agent.transform.forward;
            var predictSpeed = Time.fixedDeltaTime * agent.VelocityLimit * forward;
            wanderPosition = pos + predictSpeed * aheadDistance;
            count = repeatFrame;
            Debug.DrawLine(pos, wanderPosition, Color.blue, repeatFrame * Time.fixedDeltaTime);
            return seek.GetDesiredVelocity(agent, wanderPosition);
        }
    }
}