namespace Victor.Agents.Input
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public interface IInputProvider
    {
        event Action<Vector2> OnMove;

        event Action<Vector2> OnTap;

        void Enable();

        void Disable();
    }

    public class InputProvider : IInputProvider
    {
        public event Action<Vector2> OnMove;
        public event Action<Vector2> OnTap;

        private Vector2 PointerPosition => Pointer.current.position.ReadValue();

        private readonly InputActions actions;

        public InputProvider()
        {
            actions = new InputActions();
            BindInputActionsEvents();
            Enable();
        }

        private void BindInputActionsEvents()
        {
            var game = actions.Game;

            game.Movement.performed += context => OnMove?.Invoke(context.ReadValue<Vector2>());
            game.Fire.performed += _ => OnTap?.Invoke(PointerPosition);
        }

        public void Enable()
        {
            actions.Enable();
        }

        public void Disable()
        {
            actions.Disable();
        }
    }
}
