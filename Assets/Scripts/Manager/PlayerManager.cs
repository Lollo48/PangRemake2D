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


    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        m_playerTransform = GetComponent<Transform>();
        playerStateManager = new PlayerStateManager(m_playerTransform, playerRigidBody);
        playerStateManager.CurrentState = playerStateManager.ListOfStates[PlayerState.Idle];
        inputHandler = GetComponent<PlayerInputHandler>();


    }


    private void Update()
    {
        playerStateManager.CurrentState.OnUpdate();
        inputHandler.HandleAllInputs();
        UpdateStates();

    }
    

    private void UpdateStates()
    {
        if (inputHandler.horizontalInput != 0 && inputHandler.isShooting == false) playerStateManager.ChangeState(PlayerState.Walk);
        else if(inputHandler.isShooting) playerStateManager.ChangeState(PlayerState.Shoot);
        else playerStateManager.ChangeState(PlayerState.Idle);
        
    }



}
