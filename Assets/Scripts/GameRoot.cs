namespace Victor.Agents
{
    using System;
    using Areas;
    using UnityEngine;
    using Characters.Hunters;
    using Input;

    public class GameRoot : MonoBehaviour
    {
        [SerializeField]
        private HunterSpawner hunterSpawner;

        [SerializeField]
        private Area area;

        private IInputProvider inputProvider;

        private void Awake()
        {
            inputProvider = new InputProvider();
            hunterSpawner.Construct(inputProvider);
            area.Construct(hunterSpawner);
        }

        private void Start()
        {
            area.Init();
        }
    }
}
