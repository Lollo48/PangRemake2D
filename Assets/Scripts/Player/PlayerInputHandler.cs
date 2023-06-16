using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputHandler : MonoBehaviour
{

    PlayerControls m_playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public bool isShooting;
    PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        if (m_playerControls == null)
        {
            m_playerControls = new PlayerControls();
            m_playerControls.PlayerInput.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            m_playerControls.PlayerInput.Move.canceled += i => movementInput = i.ReadValue<Vector2>();
            m_playerControls.PlayerInput.Shoot.performed += i => isShooting = i.ReadValueAsButton();
            m_playerControls.PlayerInput.Shoot.canceled += i => isShooting = i.ReadValueAsButton();

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
