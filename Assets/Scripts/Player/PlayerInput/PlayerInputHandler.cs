using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{

    PlayerControls m_playerControls;
    public Vector2 MovementInput;
    public float VerticalInput;
    public float HorizontalInput;
    public bool IsShooting;

    private void OnEnable()
    {
        if (m_playerControls == null)
        {
            m_playerControls = new PlayerControls();
            m_playerControls.PlayerInput.Move.performed += i => MovementInput = i.ReadValue<Vector2>();
            m_playerControls.PlayerInput.Move.canceled += i => MovementInput = i.ReadValue<Vector2>();
            m_playerControls.PlayerInput.Shoot.performed += i => IsShooting = i.ReadValueAsButton();
            m_playerControls.PlayerInput.Shoot.canceled += i => IsShooting = i.ReadValueAsButton();

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
        VerticalInput = MovementInput.y;
        HorizontalInput = MovementInput.x;

    }

    

}
