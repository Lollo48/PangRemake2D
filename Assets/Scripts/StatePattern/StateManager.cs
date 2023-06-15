using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateManager<TKeyState> 
{

    public Dictionary<TKeyState, State<TKeyState>> ListOfStates;
    public State<TKeyState> CurrentState;
    public State<TKeyState> NextState;

    

    public StateManager(Dictionary<TKeyState, State<TKeyState>> listOfStates = null, State<TKeyState> currentState = null, State<TKeyState> nextState = null)
    {
        ListOfStates = listOfStates;
        CurrentState = currentState;
        NextState = nextState;
        SetUpStateManager();
        SetupStates();
    }

    protected virtual void SetUpStateManager()
    {
        if (ListOfStates == null) ListOfStates = new Dictionary<TKeyState, State<TKeyState>>();
        
    }


    protected abstract void SetupStates();
   

    public void ChangeState(TKeyState key)
    {
        if (CurrentState == ListOfStates[key]) return;
        NextState = CurrentState;
        CurrentState.OnExit();
        CurrentState = ListOfStates[key];
        CurrentState.OnEnter();
    }



}