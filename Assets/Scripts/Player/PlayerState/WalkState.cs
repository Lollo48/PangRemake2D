using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State<PlayerState>
{

    PlayerStateManager m_playerStateManager;
    AnimationPlayerManager m_animationManager;
    PlayerInputHandler m_playerInputManager;
    PlayerManager m_playerManager;
    Rigidbody2D m_playerRigidBody2D;
    Vector2 m_moveDirection;

    public WalkState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
    {
        m_playerStateManager = (PlayerStateManager)m_stateManager;
        //Debug.Log(playerStateManager);
    }


    /// <summary>
    /// Take rigidBody2d to mouve the player
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        if (m_playerRigidBody2D == null)
        {
            m_playerRigidBody2D = m_playerStateManager.PlayerRigidBody2D;
            //Debug.Log( playerRigidBody2D);
        }
        GameManagerInstance();
        
    }

    /// <summary>
    /// mouve the player
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();
        //Debug.Log("velocity");
        PlayerMouvement();
        m_animationManager.UpdateAnimatorValues(m_playerInputManager.HorizontalInput,true);

    }

    /// <summary>
    /// on exit set animator walk to false 
    /// set the velocity to 0 because i want to stop the player every time i exit the state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        m_animationManager.UpdateAnimatorValues(m_playerInputManager.HorizontalInput,false);
        m_playerStateManager.PlayerRigidBody2D.velocity = new Vector2(0, 0);
        
    }

    /// <summary>
    /// player mouvement function 
    /// use rigidBody.velocity
    /// </summary>
    private void PlayerMouvement()
    {
        m_moveDirection = Vector2.right * m_playerInputManager.HorizontalInput;
        m_moveDirection.Normalize();
        m_moveDirection.y = 0;
        m_moveDirection = m_moveDirection * m_playerManager.MovementSpeed * Time.deltaTime;
        m_playerStateManager.PlayerRigidBody2D.velocity = m_moveDirection;
        
        
    }


    /// <summary>
    /// all the gameManager Instance
    /// </summary>
    private void GameManagerInstance()
    {
        m_animationManager = GameManager.instance.AnimationManager;
        m_playerInputManager = GameManager.instance.PlayerInputHandler;
        m_playerManager = GameManager.instance.PlayerManager;
    } 



    
}
