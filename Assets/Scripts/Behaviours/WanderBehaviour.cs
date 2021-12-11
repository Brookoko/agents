namespace Scenes.Behaviours
{
    using Scripts;
    using UnityEngine;

    public class WanderBehaviour : AgentBehaviour
    {
        [SerializeField]
        private SeekBehaviour seek;

        [SerializeField]
        private int repeatFrame;

        [SerializeField]
        private float randomAngle;

        [SerializeField]
        private float aheadDistance;

        private int count;
        private Vector2 wanderPosition;

        public override Vector2 GetDesiredVelocity(Agent agent)
        {
            if (count > 0)
            {
                count--;
                return seek.GetDesiredVelocity(agent, wanderPosition);
            }

            var pos = agent.transform.position;
            var forward = Quaternion.AngleAxis((Random.value - 0.5f) * 2 * randomAngle, Vector3.up) *
                          agent.transform.forward;
            var predictSpeed = Time.fixedDeltaTime * agent.velocityLimit * forward.ToXZVector2();
            wanderPosition = pos.ToXZVector2() + predictSpeed * aheadDistance;
            count = repeatFrame;
            Debug.DrawLine(pos, wanderPosition.ToXZVector3(), Color.green, repeatFrame * Time.fixedDeltaTime);
            return seek.GetDesiredVelocity(agent, wanderPosition);
        }
    }
}