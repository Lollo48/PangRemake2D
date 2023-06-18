using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    PangEventManager m_eventManager;
    public int PlayerLife;


    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_eventManager.Registrer(EventName.HitPlayerEvent, UpdatePlayerLife);
    }
    


    private void UpdatePlayerLife()
    {
        PlayerLife--;
    }

}
