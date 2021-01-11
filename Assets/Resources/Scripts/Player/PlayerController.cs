// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Scripts/Player/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""FirstPersonPlayer"",
            ""id"": ""20c1d511-5970-4166-b4ba-02650ea1e5b7"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""a9f72bd3-177d-4235-b61d-6f62ae66e0ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""3f3dcc5e-f43a-454e-a381-e4cc80af8efe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""b91cad4e-617b-4d9e-9b31-8ff7460295c6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e932ae3c-da8f-453d-846c-a90a8d4c62ce"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c7d60918-68f7-46ee-80de-eeade131dc34"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fcc4dc3-9c18-48ef-94d6-81cc20365d29"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a935d6f9-3bcb-4bf0-ac78-30e0667cda3a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a7f1127-1389-4fa1-b184-0ed76db0cb60"",
                    ""path"": ""<XRController>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7b8cbee-bbf3-4133-b228-e99741e3e321"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0619468d-8857-4872-9de3-739cd00ebf52"",
                    ""path"": ""<XRController>{RightHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(y=0)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""2ab45f0c-fd0e-4c2f-b7f7-3905e67c7699"",
            ""actions"": [
                {
                    ""name"": ""EnableVR"",
                    ""type"": ""Button"",
                    ""id"": ""7a79a436-8ee6-499c-a742-cacded08a277"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Value"",
                    ""id"": ""94723431-b619-400a-bf98-119097bc430c"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5caad7fd-8c3d-464b-9dbc-c14a49c945c7"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnableVR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9effbca1-4416-4d8f-807a-ffec91cb9575"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FirstPersonPlayer
        m_FirstPersonPlayer = asset.FindActionMap("FirstPersonPlayer", throwIfNotFound: true);
        m_FirstPersonPlayer_movement = m_FirstPersonPlayer.FindAction("movement", throwIfNotFound: true);
        m_FirstPersonPlayer_look = m_FirstPersonPlayer.FindAction("look", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_EnableVR = m_UI.FindAction("EnableVR", throwIfNotFound: true);
        m_UI_Quit = m_UI.FindAction("Quit", throwIfNotFound: true);
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

    // FirstPersonPlayer
    private readonly InputActionMap m_FirstPersonPlayer;
    private IFirstPersonPlayerActions m_FirstPersonPlayerActionsCallbackInterface;
    private readonly InputAction m_FirstPersonPlayer_movement;
    private readonly InputAction m_FirstPersonPlayer_look;
    public struct FirstPersonPlayerActions
    {
        private @PlayerController m_Wrapper;
        public FirstPersonPlayerActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_FirstPersonPlayer_movement;
        public InputAction @look => m_Wrapper.m_FirstPersonPlayer_look;
        public InputActionMap Get() { return m_Wrapper.m_FirstPersonPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FirstPersonPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IFirstPersonPlayerActions instance)
        {
            if (m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnMovement;
                @look.started -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_FirstPersonPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
            }
        }
    }
    public FirstPersonPlayerActions @FirstPersonPlayer => new FirstPersonPlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_EnableVR;
    private readonly InputAction m_UI_Quit;
    public struct UIActions
    {
        private @PlayerController m_Wrapper;
        public UIActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnableVR => m_Wrapper.m_UI_EnableVR;
        public InputAction @Quit => m_Wrapper.m_UI_Quit;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @EnableVR.started -= m_Wrapper.m_UIActionsCallbackInterface.OnEnableVR;
                @EnableVR.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnEnableVR;
                @EnableVR.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnEnableVR;
                @Quit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnableVR.started += instance.OnEnableVR;
                @EnableVR.performed += instance.OnEnableVR;
                @EnableVR.canceled += instance.OnEnableVR;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IFirstPersonPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnEnableVR(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
