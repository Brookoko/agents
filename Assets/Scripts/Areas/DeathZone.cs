namespace Victor.Agents.Areas
{
    using Scenes.Scripts;
    using UnityEngine;

    public class DeathZone : MonoBehaviour
    {
        [SerializeField]
        private BoidsProvider boidsProvider;

        [SerializeField]
        private AreaBounds areaBounds;

        private void Update()
        {
            foreach (var agent in boidsProvider.Agents)
            {
                var position = agent.transform.position;
                if (!areaBounds.IsInBounds(position))
                {
                    agent.gameObject.SetActive(false);
                }
            }
        }
    }
}