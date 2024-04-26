using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    #region Variables
    private PlayerInput playerInput;
    private InputAction touchPress;

    public static event Action<Vector2> FingerPosition;
    #endregion

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPress = playerInput.actions["PickUp"];
    }

    private void OnEnable()
    {
        touchPress.performed += Pressed;
        touchPress.canceled += Removed;
    }

    private void OnDisable()
    {
        touchPress.performed -= Pressed;
        touchPress.canceled -= Removed;
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        FingerPosition?.Invoke(worldPosition);
    }

    private void Removed(InputAction.CallbackContext context)
    {
        Debug.Log("Removed");
    }

    private void PressedTest(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed Test");
    }

    private void RemovedTest(InputAction.CallbackContext context)
    {
        Debug.Log("Removed Test");
    }
}
