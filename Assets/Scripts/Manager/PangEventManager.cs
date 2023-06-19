using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangEventManager : EventManagerBase<EventName>
{
    /// <summary>
    /// PangEventManager 
    /// </summary>
    public EventName eventName;
    


}


/// <summary>
/// name for All Events
/// </summary>
public enum EventName
{
    ScoreEvent,
    HitPlayerEvent,
    ShootEvent,
    DestroyBulletEvent,
    GameOver,
    GamePause,
    GameResume
    

}
