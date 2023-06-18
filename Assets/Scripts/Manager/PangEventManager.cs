using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangEventManager : EventManagerBase<EventName>
{
    public EventName eventName;
    


}



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
