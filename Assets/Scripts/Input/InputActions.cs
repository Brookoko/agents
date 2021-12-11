// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Victor.Agents.Input
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""d12cf3c9-5d8f-49a2-83ab-05b264ceb18b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d59d979e-e58c-448a-8da9-f39415b29887"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""51b576a7-67e6-4e4a-90c2-8ef02cf84164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pointer"",
                    ""type"": ""Value"",
                    ""id"": ""c81dc6be-fdbe-4464-b6f4-5ecf17fd0383"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6de0c9be-6c55-4486-82d5-1a1173bfbb53"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""abb35cb0-ccb8-46e3-a224-c50fdbaedcdc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bc3bffaf-9f4a-4581-978d-f8f2b1619e00"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e86dfc8e-f06e-4f93-93aa-2a0b6fef4e80"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6d6f09e7-c84a-4265-b9dc-3fb922bb8b12"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7af5742a-44a5-4bdb-a3eb-fef0eec65fd4"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff2972d1-10ca-48d8-b740-641b6f4e1258"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Standalone"",
                    ""action"": ""Pointer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Standalone"",
            ""bindingGroup"": ""Standalone"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
            m_Game_Fire = m_Game.FindAction("Fire", throwIfNotFound: true);
            m_Game_Pointer = m_Game.FindAction("Pointer", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_Movement;
        private readonly InputAction m_Game_Fire;
        private readonly InputAction m_Game_Pointer;
        public struct GameActions
        {
            private @InputActions m_Wrapper;
            public GameActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Game_Movement;
            public InputAction @Fire => m_Wrapper.m_Game_Fire;
            public InputAction @Pointer => m_Wrapper.m_Game_Pointer;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Fire.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    @Pointer.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPointer;
                    @Pointer.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPointer;
                    @Pointer.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPointer;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Pointer.started += instance.OnPointer;
                    @Pointer.performed += instance.OnPointer;
                    @Pointer.canceled += instance.OnPointer;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        private int m_StandaloneSchemeIndex = -1;
        public InputControlScheme StandaloneScheme
        {
            get
            {
                if (m_StandaloneSchemeIndex == -1) m_StandaloneSchemeIndex = asset.FindControlSchemeIndex("Standalone");
                return asset.controlSchemes[m_StandaloneSchemeIndex];
            }
        }
        public interface IGameActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnPointer(InputAction.CallbackContext context);
        }
    }
}
