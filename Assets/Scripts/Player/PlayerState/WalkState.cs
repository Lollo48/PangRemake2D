using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State<PlayerState>
{

    private PlayerStateManager playerStateManager;
    AnimationPlayerManager animationManager;
    PlayerInputHandler PlayerInputManager;
    PlayerManager playerManager;
    Rigidbody2D playerRigidBody2D;
    Vector2 moveDirection;

    public WalkState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
    {
        playerStateManager = (PlayerStateManager)m_stateManager;
        //Debug.Log(playerStateManager);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameManagerInstance();
        if (playerRigidBody2D == null)
        {
            playerRigidBody2D = playerStateManager.PlayerRigidBody2D;
            //Debug.Log( playerRigidBody2D);
        }
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        //Debug.Log("velocity");
        PlayerMouvement();
        animationManager.UpdateAnimatorValues(PlayerInputManager.horizontalInput,true);

    }

    public override void OnExit()
    {
        base.OnExit();
        animationManager.UpdateAnimatorValues(PlayerInputManager.horizontalInput,false);
        playerStateManager.PlayerRigidBody2D.velocity = new Vector2(0, 0);
    }


    private void PlayerMouvement()
    {
        moveDirection = Vector2.right * PlayerInputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * playerManager.movementSpeed * Time.deltaTime;
        playerStateManager.PlayerRigidBody2D.velocity = moveDirection;
        
    }


    private void GameManagerInstance()
    {
        animationManager = GameManager.instance.AnimationManager;
        PlayerInputManager = GameManager.instance.playerInput;
        playerManager = GameManager.instance.playerManager;
    } 



    
}
