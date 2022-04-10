//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Scripts/Player/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""ced79073-d551-4611-abd3-8a092ee6fdf6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""77170337-b47e-41a7-8684-cb506629826a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""86c69330-f50a-479e-99b9-af8799ceae15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateWorld"",
                    ""type"": ""Button"",
                    ""id"": ""40810c92-75b0-4864-853c-1a1f856a2633"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CreatePlatform"",
                    ""type"": ""Button"",
                    ""id"": ""eeaa2127-a82b-4ea3-896e-57d1d94dc5bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InvertGravity"",
                    ""type"": ""Button"",
                    ""id"": ""a23263d7-a29b-4ba4-8d51-6022b405bfbe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""5a50d2be-be08-4fb7-ad4b-344cd3b2e0aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""Button"",
                    ""id"": ""efd138aa-e00f-4efd-8431-490f20d72f0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a71901ab-7d13-4f68-b675-856b16daeb31"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e55dfae8-a046-4685-af76-716243f25733"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8b8927be-7f32-4e77-a233-59f7e3855233"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e15a72ca-0d7f-4c8c-809a-54c3409cecf8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""51135d54-6ab0-4182-864b-d84ef3fc971f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84d712cf-4bea-453c-8c12-58a67b875d55"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e1b15a4a-729e-4522-a1dc-cecbbbcf73a6"",
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
                    ""id"": ""edb310e3-e407-4694-a84d-86adb6f25d45"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fab77800-3817-46f7-ba3b-044cf355c82c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateWorld"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2fc527a-59f8-4190-a6ee-3ad32883df77"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CreatePlatform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7a04969-4081-4549-9875-e1195a1bb3c7"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InvertGravity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03fee5d1-b42d-4a0f-90e7-a209d364a965"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd3e0887-df13-4efb-855f-88c085ae081f"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
        m_CharacterControls_Jump = m_CharacterControls.FindAction("Jump", throwIfNotFound: true);
        m_CharacterControls_RotateWorld = m_CharacterControls.FindAction("RotateWorld", throwIfNotFound: true);
        m_CharacterControls_CreatePlatform = m_CharacterControls.FindAction("CreatePlatform", throwIfNotFound: true);
        m_CharacterControls_InvertGravity = m_CharacterControls.FindAction("InvertGravity", throwIfNotFound: true);
        m_CharacterControls_Swing = m_CharacterControls.FindAction("Swing", throwIfNotFound: true);
        m_CharacterControls_Push = m_CharacterControls.FindAction("Push", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Move;
    private readonly InputAction m_CharacterControls_Jump;
    private readonly InputAction m_CharacterControls_RotateWorld;
    private readonly InputAction m_CharacterControls_CreatePlatform;
    private readonly InputAction m_CharacterControls_InvertGravity;
    private readonly InputAction m_CharacterControls_Swing;
    private readonly InputAction m_CharacterControls_Push;
    public struct CharacterControlsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
        public InputAction @Jump => m_Wrapper.m_CharacterControls_Jump;
        public InputAction @RotateWorld => m_Wrapper.m_CharacterControls_RotateWorld;
        public InputAction @CreatePlatform => m_Wrapper.m_CharacterControls_CreatePlatform;
        public InputAction @InvertGravity => m_Wrapper.m_CharacterControls_InvertGravity;
        public InputAction @Swing => m_Wrapper.m_CharacterControls_Swing;
        public InputAction @Push => m_Wrapper.m_CharacterControls_Push;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnJump;
                @RotateWorld.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotateWorld;
                @RotateWorld.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotateWorld;
                @RotateWorld.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotateWorld;
                @CreatePlatform.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCreatePlatform;
                @CreatePlatform.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCreatePlatform;
                @CreatePlatform.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnCreatePlatform;
                @InvertGravity.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvertGravity;
                @InvertGravity.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvertGravity;
                @InvertGravity.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvertGravity;
                @Swing.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnSwing;
                @Push.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPush;
                @Push.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPush;
                @Push.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPush;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @RotateWorld.started += instance.OnRotateWorld;
                @RotateWorld.performed += instance.OnRotateWorld;
                @RotateWorld.canceled += instance.OnRotateWorld;
                @CreatePlatform.started += instance.OnCreatePlatform;
                @CreatePlatform.performed += instance.OnCreatePlatform;
                @CreatePlatform.canceled += instance.OnCreatePlatform;
                @InvertGravity.started += instance.OnInvertGravity;
                @InvertGravity.performed += instance.OnInvertGravity;
                @InvertGravity.canceled += instance.OnInvertGravity;
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
                @Push.started += instance.OnPush;
                @Push.performed += instance.OnPush;
                @Push.canceled += instance.OnPush;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotateWorld(InputAction.CallbackContext context);
        void OnCreatePlatform(InputAction.CallbackContext context);
        void OnInvertGravity(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
        void OnPush(InputAction.CallbackContext context);
    }
}
