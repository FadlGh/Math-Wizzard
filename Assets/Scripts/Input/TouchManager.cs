using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class TouchManager : MonoBehaviour
{
    #region Variables

    // Components and actions that handle input
    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressed;

    // when to get location of finger on screen and its value
    private bool getposition;
    private Vector2 _touchPosition;

    // Information to send to PickUp script
    public static event Action<Vector2> FingerPressed;
    public static event Action FingerReleased;
    #endregion

    #region Getters and Setters
    public Vector2 TouchPosition
    {
        get
        {
            return _touchPosition;
        }
    }
    #endregion

    #region Awake and Update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["PickUp"];
        touchPressed = playerInput.actions["ScreenPressed"];
    }

    private void Update()
    {
        if (getposition)
        {
            _touchPosition = touchPositionAction.ReadValue<Vector2>();
        }
    }
    #endregion

    #region Methods for Input Logic
    private void Pressed(InputAction.CallbackContext context)
    {
        getposition = true;
        FingerPressed?.Invoke(touchPositionAction.ReadValue<Vector2>());
    }

    private void Removed(InputAction.CallbackContext context)
    {
        getposition = false;
        FingerReleased?.Invoke();
    }
    #endregion

    #region OnEnable and OnDisable
    private void OnEnable()
    {
        touchPressed.started += Pressed;
        touchPressed.performed += Removed;
        touchPressed.canceled += Removed;
    }

    private void OnDisable()
    {
        touchPressed.started -= Pressed;
        touchPressed.performed -= Removed;
        touchPressed.canceled -= Removed;
    }
    #endregion
}
