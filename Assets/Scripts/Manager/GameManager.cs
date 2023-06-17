using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public AnimationPlayerManager AnimationManager;
    public PlayerInputHandler playerInputHandler;
    public PlayerManager playerManager;
    public EventManager eventManager;
    public BallManager ballManager;


}
