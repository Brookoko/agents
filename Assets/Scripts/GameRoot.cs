namespace Victor.Agents
{
    using Areas;
    using Cameras;
    using UnityEngine;
    using Characters.Hunters;
    using Input;

    public class GameRoot : MonoBehaviour
    {
        [SerializeField]
        private HunterSpawner hunterSpawner;

        [SerializeField]
        private Area area;

        [SerializeField]
        private GameCamerasController gameCamerasController;

        private IInputProvider inputProvider;

        private void Awake()
        {
            inputProvider = new InputProvider();
            hunterSpawner.Construct(inputProvider, area);
            area.Construct(hunterSpawner, gameCamerasController);
        }

        private void Start()
        {
            area.Init();
        }
    }
}
