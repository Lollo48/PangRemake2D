using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State<PlayerState>
{
    Transform m_playerTransform;
    PlayerStateManager m_playerStateManager;
    PlayerInputHandler m_playerInputManager;
    PlayerManager m_playerManager;
    PlayerWeapon m_playerWeapon;
    AnimationPlayerManager animationPlayer;
    PangEventManager eventManager;


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
            m_playerWeapon = m_playerStateManager.PlayerTransform.GetComponent<PlayerWeapon>();
            //Debug.Log( playerRigidBody2D);
        }
        GameManagerInstance();
        eventManager.TriggerEvent(EventName.ShootEvent);
        animationPlayer.UpdateAnimatorShootingBool(true);
        m_playerInputManager.IsShooting = false;
        m_playerManager.CanShoot = false;
    }


    public override void OnUpdate()
    {
        base.OnUpdate();
        m_playerWeapon.Shoot(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        m_playerManager.InvokeCanShoot();
        animationPlayer.UpdateAnimatorShootingBool(false);
    }


    private void GameManagerInstance()
    {
        eventManager = GameManager.instance.PangEventManager;
        animationPlayer = GameManager.instance.AnimationManager;
        m_playerInputManager = GameManager.instance.PlayerInputHandler;
        m_playerManager = GameManager.instance.PlayerManager;
    }





}
