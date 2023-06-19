using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsBase : MonoBehaviour
{
    PangEventManager m_eventManager;
    public int Life;


    protected virtual void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_eventManager.Registrer(EventName.HitPlayerEvent, UpdatePlayerLife);
    }



    protected virtual void UpdatePlayerLife()
    {
        Life--;
    }



}
