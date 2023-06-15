using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<PlayerState>
{
    private PlayerStateManager playerStateManager;

    public IdleState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState,stateManager)
    {
        playerStateManager = (PlayerStateManager)m_stateManager;

    }


    public override void OnEnter()
    {
        base.OnEnter();
        


    }


    public override void OnUpdate()
    {
        base.OnUpdate();
      
    }

    public override void OnExit()
    {
        base.OnExit();
    

    }



}
