using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    PlayerControls m_playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;


    private void OnEnable()
    {
        if (m_playerControls == null)
        {
            m_playerControls = new PlayerControls();
            m_playerControls.PlayerInput.Move.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        m_playerControls.Enable();
    }


    private void OnDisable()
    {
        m_playerControls.Disable();
    }


    public void HandleAllInputs()
    {
        HandleMovementInput();
    }


    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }



}
