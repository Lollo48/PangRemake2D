using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State<PlayerState>
{
    /// <summary>
    /// i want to make a refactoring to this state 
    /// i have less time to do it 
    /// i think this class can be more simple
    /// for example i will use the delegate 
    /// </summary>


    Transform m_playerTransform;
    PlayerStateManager m_playerStateManager;
    PlayerInputHandler m_playerInputManager;
    PlayerManager m_playerManager;
    PlayerWeapon m_playerWeapon;
    AnimationPlayerManager m_animationPlayer;
    PangEventManager m_eventManager;


    public ShootState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
    {
        m_playerStateManager = (PlayerStateManager)m_stateManager;
        //Debug.Log(playerStateManager);
    }

    /// <summary>
    /// take playerWeapon with the transform 
    /// trigger the event 
    /// update the shoot animation
    /// and imposte to false all the condition to soot
    /// </summary>
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
        m_eventManager.TriggerEvent(EventName.ShootEvent);
        m_animationPlayer.UpdateAnimatorShootingBool(true);
        m_playerInputManager.IsShooting = false;
        m_playerManager.CanShoot = false;
    }


    /// <summary>
    /// shoot
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();
        m_playerWeapon.Shoot(true);
    }

    /// <summary>
    /// invoke the deelay method 
    /// set animator shoot to false 
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        m_playerManager.InvokeCanShoot();
        m_animationPlayer.UpdateAnimatorShootingBool(false);
    }


    private void GameManagerInstance()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_animationPlayer = GameManager.instance.AnimationManager;
        m_playerInputManager = GameManager.instance.PlayerInputHandler;
        m_playerManager = GameManager.instance.PlayerManager;
    }





}
