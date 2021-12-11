namespace Victor.Agents.Cameras
{
    using UnityEngine;

    public class GameCamerasController : MonoBehaviour
    {
        [field: SerializeField]
        public VirtualCamera CurrentCamera { get; private set; }
    }
}
