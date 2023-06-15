using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : StateManager<PlayerState>
{
    public Rigidbody2D PlayerRigidBody2D;
    public Transform PlayerTransform;


    public PlayerStateManager(Transform playerTransform, Rigidbody2D playerRigidBody2D, Dictionary<PlayerState, State<PlayerState>> listOfSTtes = null , State<PlayerState> currentState = null, State<PlayerState> nextState = null) : base(listOfSTtes,currentState,nextState)
    {
        PlayerTransform = playerTransform;
        PlayerRigidBody2D = playerRigidBody2D;
        Debug.Log(PlayerRigidBody2D);
    }



    protected override void SetupStates()
    {
        ListOfStates.Add(PlayerState.Idle, new IdleState(PlayerState.Idle, this));
        ListOfStates.Add(PlayerState.Walk, new WalkState(PlayerState.Walk, this));
    }


}



public enum PlayerState
{
    Idle,
    Walk,
    Shoot

}