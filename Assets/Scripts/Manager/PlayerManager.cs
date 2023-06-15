using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInputHandler inputManager;
    Rigidbody2D playerRigidBody;
    PlayerStateManager playerStateManager;
    public float movementSpeed;


    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerStateManager = new PlayerStateManager(transform, playerRigidBody);
        playerStateManager.CurrentState = playerStateManager.ListOfStates[PlayerState.Idle];
        inputManager = GetComponent<PlayerInputHandler>();

    }


    private void Update()
    {
        playerStateManager.CurrentState.OnUpdate();
        inputManager.HandleAllInputs();
        UpdateStates();
    }
    

    private void UpdateStates()
    {
        if (inputManager.horizontalInput != 0) playerStateManager.ChangeState(PlayerState.Walk);
        else playerStateManager.ChangeState(PlayerState.Idle);

    }


}
