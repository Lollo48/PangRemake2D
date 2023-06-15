using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{

    PlayerControls m_playerControls;
    PlayerShooting playerShooting;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;


    private void Awake()
    {
        playerShooting = GetComponent<PlayerShooting>();
    }


    private void OnEnable()
    {
        if (m_playerControls == null)
        {
            m_playerControls = new PlayerControls();
            m_playerControls.PlayerInput.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            m_playerControls.PlayerInput.Shoot.performed += playerShooting.Shooting;
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
