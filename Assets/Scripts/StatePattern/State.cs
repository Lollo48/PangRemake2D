using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State<TKeyState>
{
    protected StateManager<TKeyState> m_stateManager;
    public TKeyState m_nameOfState;

    public State(TKeyState keyState,StateManager<TKeyState> stateManager = null)
    {
        this.m_stateManager = stateManager;
        m_nameOfState = keyState;
    }

    public virtual void OnEnter() { /*Debug.Log("OnEnter " + nameOfState);*/ }
    public virtual void OnUpdate() { /*Debug.Log("OnUpdate " + m_nameOfState);*/ }
    public virtual void OnExit() { /*Debug.Log("OnExit " + nameOfState);*/ }
}
