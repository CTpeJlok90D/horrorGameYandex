//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Player/Scripts/PlayerInputMap.inputactions
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

public partial class @PlayerInputMap : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""791b4e49-a49f-47cf-8942-fce772f44606"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d0b0d187-98b8-44d1-8fbc-a5ec9c07b6e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""bdd11459-705f-4265-9096-df11ec01499f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""f563834c-62f0-4ac3-8841-609d7ffaa654"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowBook"",
                    ""type"": ""Button"",
                    ""id"": ""92aadfaf-eac1-44b1-a3b9-fe4e5dda8b7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseHint"",
                    ""type"": ""Button"",
                    ""id"": ""86599b98-4b67-4f1f-a6c6-1075ce555513"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenEscMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2207531b-057b-414f-9824-44384691529d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""Value"",
                    ""id"": ""91cb7189-3d72-4509-95e6-83711eac3a30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""f24d8b34-bf6c-4544-a202-306e93a46dea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0c2ac646-c676-44f3-9181-cd5e8e8699f0"",
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
                    ""id"": ""6df70afe-79d9-4937-a5af-4e8fd4d786e5"",
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
                    ""id"": ""4d2e089d-df9d-42e9-aed4-9ddc5976aa88"",
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
                    ""id"": ""4ca5b847-b0d2-489b-9f11-4ce6aeba57ca"",
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
                    ""id"": ""52069fe0-1516-41bb-bd60-b2ff921a5588"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f49d204d-d8ad-4909-a1cf-37369b9f9017"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1588baf6-7fec-4470-abcb-128640ab9b5d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""806640b3-863a-4e6b-8f44-11fcd7fc97c8"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35059651-bb85-4f53-9a1d-da43fe055365"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowBook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9c55898-8f87-4901-8c75-899b2b5a5e00"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseHint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7ee3b65-af09-47e3-93ba-417e39dbfe43"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenEscMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9a7c38d-8053-4017-94c9-a3be7043c1aa"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interact"",
            ""id"": ""3cf346fa-5a0c-452d-b54e-714cb92d8bcd"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""71a74cdf-d8e8-4f8b-af75-31382b3316a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5b9b9034-5ce0-4df7-b03b-c42b5e42a3ae"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LookingItem"",
            ""id"": ""25752afa-61ef-44b1-bd4c-b28fc2ecb512"",
            ""actions"": [
                {
                    ""name"": ""StopLooking"",
                    ""type"": ""Button"",
                    ""id"": ""0a470af8-59c4-4c1c-8bd9-c26508d8b5bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""5212d7de-c2b6-4486-82dc-48be724a4009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""65bda37d-dc52-414e-aa25-d294e11ab807"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ab08242-eeab-4e99-a5dc-594931dac31a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopLooking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53ba9af1-b81a-4ee7-b42a-5a24eb8606a8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d41cfeba-b13b-472f-b3b6-545c00a382ed"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f2a1b8f-bae5-4b9b-948a-c9b31056e857"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34a22911-f12a-4118-b867-271dc12c24b4"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EscMenu"",
            ""id"": ""1d585a37-a1d1-4095-9380-ff5880813c63"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""24b18c7d-15fa-4948-b339-05c3d9c4702b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b366badf-13da-4e9c-b531-bf61e84b66f4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovement_Look = m_PlayerMovement.FindAction("Look", throwIfNotFound: true);
        m_PlayerMovement_Crouch = m_PlayerMovement.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerMovement_ThrowBook = m_PlayerMovement.FindAction("ThrowBook", throwIfNotFound: true);
        m_PlayerMovement_UseHint = m_PlayerMovement.FindAction("UseHint", throwIfNotFound: true);
        m_PlayerMovement_OpenEscMenu = m_PlayerMovement.FindAction("OpenEscMenu", throwIfNotFound: true);
        m_PlayerMovement_TouchDelta = m_PlayerMovement.FindAction("TouchDelta", throwIfNotFound: true);
        // Interact
        m_Interact = asset.FindActionMap("Interact", throwIfNotFound: true);
        m_Interact_Interact = m_Interact.FindAction("Interact", throwIfNotFound: true);
        // LookingItem
        m_LookingItem = asset.FindActionMap("LookingItem", throwIfNotFound: true);
        m_LookingItem_StopLooking = m_LookingItem.FindAction("StopLooking", throwIfNotFound: true);
        m_LookingItem_Rotate = m_LookingItem.FindAction("Rotate", throwIfNotFound: true);
        m_LookingItem_MouseDelta = m_LookingItem.FindAction("MouseDelta", throwIfNotFound: true);
        // EscMenu
        m_EscMenu = asset.FindActionMap("EscMenu", throwIfNotFound: true);
        m_EscMenu_Close = m_EscMenu.FindAction("Close", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Move;
    private readonly InputAction m_PlayerMovement_Look;
    private readonly InputAction m_PlayerMovement_Crouch;
    private readonly InputAction m_PlayerMovement_ThrowBook;
    private readonly InputAction m_PlayerMovement_UseHint;
    private readonly InputAction m_PlayerMovement_OpenEscMenu;
    private readonly InputAction m_PlayerMovement_TouchDelta;
    public struct PlayerMovementActions
    {
        private @PlayerInputMap m_Wrapper;
        public PlayerMovementActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
        public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
        public InputAction @Crouch => m_Wrapper.m_PlayerMovement_Crouch;
        public InputAction @ThrowBook => m_Wrapper.m_PlayerMovement_ThrowBook;
        public InputAction @UseHint => m_Wrapper.m_PlayerMovement_UseHint;
        public InputAction @OpenEscMenu => m_Wrapper.m_PlayerMovement_OpenEscMenu;
        public InputAction @TouchDelta => m_Wrapper.m_PlayerMovement_TouchDelta;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnLook;
                @Crouch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @ThrowBook.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrowBook;
                @ThrowBook.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrowBook;
                @ThrowBook.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnThrowBook;
                @UseHint.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseHint;
                @UseHint.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseHint;
                @UseHint.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnUseHint;
                @OpenEscMenu.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOpenEscMenu;
                @OpenEscMenu.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOpenEscMenu;
                @OpenEscMenu.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOpenEscMenu;
                @TouchDelta.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTouchDelta;
                @TouchDelta.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTouchDelta;
                @TouchDelta.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTouchDelta;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @ThrowBook.started += instance.OnThrowBook;
                @ThrowBook.performed += instance.OnThrowBook;
                @ThrowBook.canceled += instance.OnThrowBook;
                @UseHint.started += instance.OnUseHint;
                @UseHint.performed += instance.OnUseHint;
                @UseHint.canceled += instance.OnUseHint;
                @OpenEscMenu.started += instance.OnOpenEscMenu;
                @OpenEscMenu.performed += instance.OnOpenEscMenu;
                @OpenEscMenu.canceled += instance.OnOpenEscMenu;
                @TouchDelta.started += instance.OnTouchDelta;
                @TouchDelta.performed += instance.OnTouchDelta;
                @TouchDelta.canceled += instance.OnTouchDelta;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Interact
    private readonly InputActionMap m_Interact;
    private IInteractActions m_InteractActionsCallbackInterface;
    private readonly InputAction m_Interact_Interact;
    public struct InteractActions
    {
        private @PlayerInputMap m_Wrapper;
        public InteractActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Interact_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interact; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractActions set) { return set.Get(); }
        public void SetCallbacks(IInteractActions instance)
        {
            if (m_Wrapper.m_InteractActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_InteractActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractActions @Interact => new InteractActions(this);

    // LookingItem
    private readonly InputActionMap m_LookingItem;
    private ILookingItemActions m_LookingItemActionsCallbackInterface;
    private readonly InputAction m_LookingItem_StopLooking;
    private readonly InputAction m_LookingItem_Rotate;
    private readonly InputAction m_LookingItem_MouseDelta;
    public struct LookingItemActions
    {
        private @PlayerInputMap m_Wrapper;
        public LookingItemActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @StopLooking => m_Wrapper.m_LookingItem_StopLooking;
        public InputAction @Rotate => m_Wrapper.m_LookingItem_Rotate;
        public InputAction @MouseDelta => m_Wrapper.m_LookingItem_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_LookingItem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LookingItemActions set) { return set.Get(); }
        public void SetCallbacks(ILookingItemActions instance)
        {
            if (m_Wrapper.m_LookingItemActionsCallbackInterface != null)
            {
                @StopLooking.started -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnStopLooking;
                @StopLooking.performed -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnStopLooking;
                @StopLooking.canceled -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnStopLooking;
                @Rotate.started -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnRotate;
                @MouseDelta.started -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_LookingItemActionsCallbackInterface.OnMouseDelta;
            }
            m_Wrapper.m_LookingItemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StopLooking.started += instance.OnStopLooking;
                @StopLooking.performed += instance.OnStopLooking;
                @StopLooking.canceled += instance.OnStopLooking;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }
        }
    }
    public LookingItemActions @LookingItem => new LookingItemActions(this);

    // EscMenu
    private readonly InputActionMap m_EscMenu;
    private IEscMenuActions m_EscMenuActionsCallbackInterface;
    private readonly InputAction m_EscMenu_Close;
    public struct EscMenuActions
    {
        private @PlayerInputMap m_Wrapper;
        public EscMenuActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Close => m_Wrapper.m_EscMenu_Close;
        public InputActionMap Get() { return m_Wrapper.m_EscMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EscMenuActions set) { return set.Get(); }
        public void SetCallbacks(IEscMenuActions instance)
        {
            if (m_Wrapper.m_EscMenuActionsCallbackInterface != null)
            {
                @Close.started -= m_Wrapper.m_EscMenuActionsCallbackInterface.OnClose;
                @Close.performed -= m_Wrapper.m_EscMenuActionsCallbackInterface.OnClose;
                @Close.canceled -= m_Wrapper.m_EscMenuActionsCallbackInterface.OnClose;
            }
            m_Wrapper.m_EscMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Close.started += instance.OnClose;
                @Close.performed += instance.OnClose;
                @Close.canceled += instance.OnClose;
            }
        }
    }
    public EscMenuActions @EscMenu => new EscMenuActions(this);
    public interface IPlayerMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnThrowBook(InputAction.CallbackContext context);
        void OnUseHint(InputAction.CallbackContext context);
        void OnOpenEscMenu(InputAction.CallbackContext context);
        void OnTouchDelta(InputAction.CallbackContext context);
    }
    public interface IInteractActions
    {
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface ILookingItemActions
    {
        void OnStopLooking(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface IEscMenuActions
    {
        void OnClose(InputAction.CallbackContext context);
    }
}
