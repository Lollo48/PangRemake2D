using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInputHandler inputHandler;
    Rigidbody2D playerRigidBody;
    Transform m_playerTransform;
    PlayerStateManager playerStateManager;
    public float movementSpeed;
    public bool canShoot;
    public float fireRate;


    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        m_playerTransform = GetComponent<Transform>();
        playerStateManager = new PlayerStateManager(m_playerTransform, playerRigidBody);
        playerStateManager.CurrentState = playerStateManager.ListOfStates[PlayerState.Idle];
        inputHandler = GetComponent<PlayerInputHandler>();
        canShoot = true;
        

    }


    private void Update()
    {
        playerStateManager.CurrentState.OnUpdate();
        inputHandler.HandleAllInputs();
        UpdateStates();


    }
    
    public void InvokeCanShoot()
    {
        Invoke("SetCanShoot", fireRate);
        
    }

    private void SetCanShoot()
    {
        canShoot = true;
        
    }

    private void UpdateStates()
    {
        if (inputHandler.horizontalInput != 0 && !inputHandler.isShooting ) playerStateManager.ChangeState(PlayerState.Walk);
        else if(inputHandler.isShooting && canShoot ) playerStateManager.ChangeState(PlayerState.Shoot);
        else if (!inputHandler.isShooting) playerStateManager.ChangeState(PlayerState.Idle);
        
    }



}
