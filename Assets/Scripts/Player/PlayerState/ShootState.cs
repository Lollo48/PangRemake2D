using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State<PlayerState>
{

    PlayerStateManager m_playerStateManager;
    AnimationPlayerManager m_animationManager;
    PlayerInputHandler m_playerInputManager;
    Transform m_playerTransform;
    PlayerWeapon playerWeapon;


    public ShootState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
    {
        m_playerStateManager = (PlayerStateManager)m_stateManager;
        //Debug.Log(playerStateManager);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_playerTransform == null)
        {
            m_playerTransform = m_playerStateManager.PlayerTransform;
            playerWeapon = m_playerStateManager.PlayerTransform.GetComponent<PlayerWeapon>();
            //Debug.Log( playerTransform);
        }
        GameManagerInstance();
        m_animationManager.UpdateAnimatorShootingBool(true); 
        m_playerInputManager.isShooting = false;

    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        playerWeapon.Shooting();

    }

    public override void OnExit()
    {
        base.OnExit();
        m_animationManager.UpdateAnimatorShootingBool(false);

    }


    private void GameManagerInstance()
    {
        m_animationManager = GameManager.instance.AnimationManager;
        m_playerInputManager = GameManager.instance.playerInput;

    }





}
