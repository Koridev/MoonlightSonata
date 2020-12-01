// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""457e5315-1539-47f2-a813-13c25de1b64e"",
            ""actions"": [
                {
                    ""name"": ""InteractDown"",
                    ""type"": ""Button"",
                    ""id"": ""0ee247cf-3e2d-403f-ae95-3e7905f8b7be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InteractUp"",
                    ""type"": ""Button"",
                    ""id"": ""4909907b-9966-4e08-adf2-b6d586ca1136"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look X"",
                    ""type"": ""Value"",
                    ""id"": ""077af77f-d4b4-4f07-9345-fb006f74830e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look Y"",
                    ""type"": ""Value"",
                    ""id"": ""714cf956-ed4a-44e8-858b-dc941e34bc78"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Value"",
                    ""id"": ""04532e1b-b8d0-4e9d-acad-9c1e125ba89c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryDown"",
                    ""type"": ""Button"",
                    ""id"": ""aedd5553-0bd7-4007-a79d-0c09fcda7626"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryUp"",
                    ""type"": ""Button"",
                    ""id"": ""faf7f22a-c801-4ed6-8709-a012b9c891dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2ba827b-4b2d-4179-b5de-70a53c057a32"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""InteractDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cacac25-f4b4-4446-a234-8e12e5203158"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""InteractUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6970110-57fc-44a2-8320-a1048e229142"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Look X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""505f8c07-d1bb-4489-8c25-08ccff22b7a5"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Look Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""941f40b7-3637-4109-ab77-68d102abf721"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spin"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3aa57814-38d2-48a8-a4d4-27978923c8b7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""de48635c-2b60-45a3-b1e1-d38d93b95205"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""83fd5c5e-8b04-4a03-bc43-9aa16af8b2a1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SecondaryDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4970ca80-919d-4b80-be3f-58c8f7fe913c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""SecondaryUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_InteractDown = m_Default.FindAction("InteractDown", throwIfNotFound: true);
        m_Default_InteractUp = m_Default.FindAction("InteractUp", throwIfNotFound: true);
        m_Default_LookX = m_Default.FindAction("Look X", throwIfNotFound: true);
        m_Default_LookY = m_Default.FindAction("Look Y", throwIfNotFound: true);
        m_Default_Spin = m_Default.FindAction("Spin", throwIfNotFound: true);
        m_Default_SecondaryDown = m_Default.FindAction("SecondaryDown", throwIfNotFound: true);
        m_Default_SecondaryUp = m_Default.FindAction("SecondaryUp", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_InteractDown;
    private readonly InputAction m_Default_InteractUp;
    private readonly InputAction m_Default_LookX;
    private readonly InputAction m_Default_LookY;
    private readonly InputAction m_Default_Spin;
    private readonly InputAction m_Default_SecondaryDown;
    private readonly InputAction m_Default_SecondaryUp;
    public struct DefaultActions
    {
        private @InputActions m_Wrapper;
        public DefaultActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @InteractDown => m_Wrapper.m_Default_InteractDown;
        public InputAction @InteractUp => m_Wrapper.m_Default_InteractUp;
        public InputAction @LookX => m_Wrapper.m_Default_LookX;
        public InputAction @LookY => m_Wrapper.m_Default_LookY;
        public InputAction @Spin => m_Wrapper.m_Default_Spin;
        public InputAction @SecondaryDown => m_Wrapper.m_Default_SecondaryDown;
        public InputAction @SecondaryUp => m_Wrapper.m_Default_SecondaryUp;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @InteractDown.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractDown;
                @InteractDown.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractDown;
                @InteractDown.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractDown;
                @InteractUp.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractUp;
                @InteractUp.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractUp;
                @InteractUp.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteractUp;
                @LookX.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookX;
                @LookX.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookX;
                @LookX.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookX;
                @LookY.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookY;
                @LookY.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookY;
                @LookY.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLookY;
                @Spin.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSpin;
                @SecondaryDown.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryDown;
                @SecondaryDown.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryDown;
                @SecondaryDown.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryDown;
                @SecondaryUp.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryUp;
                @SecondaryUp.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryUp;
                @SecondaryUp.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSecondaryUp;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @InteractDown.started += instance.OnInteractDown;
                @InteractDown.performed += instance.OnInteractDown;
                @InteractDown.canceled += instance.OnInteractDown;
                @InteractUp.started += instance.OnInteractUp;
                @InteractUp.performed += instance.OnInteractUp;
                @InteractUp.canceled += instance.OnInteractUp;
                @LookX.started += instance.OnLookX;
                @LookX.performed += instance.OnLookX;
                @LookX.canceled += instance.OnLookX;
                @LookY.started += instance.OnLookY;
                @LookY.performed += instance.OnLookY;
                @LookY.canceled += instance.OnLookY;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
                @SecondaryDown.started += instance.OnSecondaryDown;
                @SecondaryDown.performed += instance.OnSecondaryDown;
                @SecondaryDown.canceled += instance.OnSecondaryDown;
                @SecondaryUp.started += instance.OnSecondaryUp;
                @SecondaryUp.performed += instance.OnSecondaryUp;
                @SecondaryUp.canceled += instance.OnSecondaryUp;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    public interface IDefaultActions
    {
        void OnInteractDown(InputAction.CallbackContext context);
        void OnInteractUp(InputAction.CallbackContext context);
        void OnLookX(InputAction.CallbackContext context);
        void OnLookY(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
        void OnSecondaryDown(InputAction.CallbackContext context);
        void OnSecondaryUp(InputAction.CallbackContext context);
    }
}
