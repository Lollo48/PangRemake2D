using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State<PlayerState>
{
    Transform PlayerTransform;
    PlayerStateManager m_playerStateManager;
    AnimationPlayerManager m_animationManager;
    PlayerInputHandler m_playerInputManager;
    PlayerManager playerManager;
    PlayerWeapon playerWeapon;



    public ShootState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
    {
        m_playerStateManager = (PlayerStateManager)m_stateManager;
        //Debug.Log(playerStateManager);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (PlayerTransform == null)
        {
            PlayerTransform = m_playerStateManager.PlayerTransform;
            playerWeapon = m_playerStateManager.PlayerTransform.GetComponent<PlayerWeapon>();
            //Debug.Log( playerRigidBody2D);
        }
        GameManagerInstance();
        playerWeapon.Shoot(false);
        m_animationManager.UpdateAnimatorShootingBool(true);
        m_playerInputManager.isShooting = false;
        playerManager.canShoot = false;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        playerWeapon.Shoot(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        m_animationManager.UpdateAnimatorShootingBool(false);
        playerManager.InvokeCanShoot();
    }


    private void GameManagerInstance()
    {
        m_animationManager = GameManager.instance.AnimationManager;
        m_playerInputManager = GameManager.instance.playerInputHandler;
        playerManager = GameManager.instance.playerManager;
    }





}
