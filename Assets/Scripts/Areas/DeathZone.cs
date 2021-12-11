namespace Victor.Agents.Areas
{
    using UnityEngine;

    public class DeathZone : MonoBehaviour
    {
        [SerializeField]
        private EntityProvider entityProvider;

        [SerializeField]
        private AreaBounds areaBounds;

        private void Update()
        {
            foreach (var entity in entityProvider.entities)
            {
                var position = entity.Position;
                if (!areaBounds.IsInBounds(position))
                {
                    entity.Die();
                }
            }
        }
    }
}