//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputControllers/PlayerControlls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""46781a3e-8f37-4a55-becb-cfbb526b1d36"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c207522b-7a2a-48fa-bdf9-e7bfa4fc15b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveInPad"",
                    ""type"": ""Value"",
                    ""id"": ""decf2a7a-7db9-4aee-bb76-9433e772bc24"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveInStick"",
                    ""type"": ""Value"",
                    ""id"": ""8e9b6179-bf5b-42bd-a216-3a2b26a6f1c7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftArrow"",
                    ""type"": ""Button"",
                    ""id"": ""29ec8bea-5f1d-409d-a497-094a56eaa422"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightArrow"",
                    ""type"": ""Button"",
                    ""id"": ""716d8f33-05bc-4f5f-b9ae-ee64ece45cb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""75c686e6-2c97-4e52-b82d-6d0ad879790e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c3fd06f-e971-4738-9de8-628d2bc44e4c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6ea0242-e1d8-4909-8687-3670256d3f52"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2af84672-bb4c-4b63-8577-d00f4fda5b4b"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fe0defe-cedb-449e-beae-fff01f2f6172"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeab6c31-4671-4392-bb1d-3978775106c3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_MoveInPad = m_Gameplay.FindAction("MoveInPad", throwIfNotFound: true);
        m_Gameplay_MoveInStick = m_Gameplay.FindAction("MoveInStick", throwIfNotFound: true);
        m_Gameplay_LeftArrow = m_Gameplay.FindAction("LeftArrow", throwIfNotFound: true);
        m_Gameplay_RightArrow = m_Gameplay.FindAction("RightArrow", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_MoveInPad;
    private readonly InputAction m_Gameplay_MoveInStick;
    private readonly InputAction m_Gameplay_LeftArrow;
    private readonly InputAction m_Gameplay_RightArrow;
    public struct GameplayActions
    {
        private @PlayerControlls m_Wrapper;
        public GameplayActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @MoveInPad => m_Wrapper.m_Gameplay_MoveInPad;
        public InputAction @MoveInStick => m_Wrapper.m_Gameplay_MoveInStick;
        public InputAction @LeftArrow => m_Wrapper.m_Gameplay_LeftArrow;
        public InputAction @RightArrow => m_Wrapper.m_Gameplay_RightArrow;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @MoveInPad.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInPad;
                @MoveInPad.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInPad;
                @MoveInPad.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInPad;
                @MoveInStick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInStick;
                @MoveInStick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInStick;
                @MoveInStick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveInStick;
                @LeftArrow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftArrow;
                @LeftArrow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftArrow;
                @RightArrow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightArrow;
                @RightArrow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightArrow;
                @RightArrow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightArrow;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MoveInPad.started += instance.OnMoveInPad;
                @MoveInPad.performed += instance.OnMoveInPad;
                @MoveInPad.canceled += instance.OnMoveInPad;
                @MoveInStick.started += instance.OnMoveInStick;
                @MoveInStick.performed += instance.OnMoveInStick;
                @MoveInStick.canceled += instance.OnMoveInStick;
                @LeftArrow.started += instance.OnLeftArrow;
                @LeftArrow.performed += instance.OnLeftArrow;
                @LeftArrow.canceled += instance.OnLeftArrow;
                @RightArrow.started += instance.OnRightArrow;
                @RightArrow.performed += instance.OnRightArrow;
                @RightArrow.canceled += instance.OnRightArrow;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMoveInPad(InputAction.CallbackContext context);
        void OnMoveInStick(InputAction.CallbackContext context);
        void OnLeftArrow(InputAction.CallbackContext context);
        void OnRightArrow(InputAction.CallbackContext context);
    }
}
