namespace Victor.Agents.Cameras
{
    using Cinemachine;
    using UnityEngine;

    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class VirtualCamera : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        protected CinemachineVirtualCamera cm;

        public void LookAt(Transform target)
        {
            cm.m_Follow = cm.m_LookAt = target;
        }

        public void ResetLook()
        {
            cm.m_Follow = cm.m_LookAt = null;
        }
    }
}
