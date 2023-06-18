using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventManagerBase<TKeyEvent> : MonoBehaviour
{

    protected Dictionary<TKeyEvent, List<Action>> m_eventMap = new Dictionary<TKeyEvent, List<Action>>();


    public void Registrer(TKeyEvent eventName, Action observer)
    {
        if (!ValidPreCondition(eventName, observer)) return;

        if (!m_eventMap.ContainsKey(eventName))
            m_eventMap.Add(eventName, new List<Action>());

        m_eventMap[eventName].Add(observer);
        //Debug.Log("Someone is register");
        //Debug.Log(eventName);

    }

    public void UnRegistrer(TKeyEvent eventName, Action observer)
    {
        if (!ValidPreCondition(eventName, observer)) return;

        if (!m_eventMap.ContainsKey(eventName)) return;

        List<Action> event_observer = m_eventMap[eventName];

        event_observer.Remove(observer);
    }

    public void TriggerEvent(TKeyEvent eventName)
    {
        if (m_eventMap.ContainsKey(eventName))
        {
            List<Action> event_observer = m_eventMap[eventName];

            foreach (Action notify in event_observer)
                notify.Invoke();

        }
    }

    private bool ValidPreCondition(TKeyEvent eventName, Action observer)
    {
        if (observer == null) return false;

        //if (string.IsNullOrEmpty(eventName.ToString())) return false;

        return true;
    }

}




