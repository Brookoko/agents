namespace Scenes.Scripts
{
    using UnityEngine;
    using Victor.Agents.Input;

    public class GameRoot : MonoBehaviour
    {
        private IInputProvider inputProvider;

        private void Awake()
        {
            inputProvider = new InputProvider();
        }
    }
}
