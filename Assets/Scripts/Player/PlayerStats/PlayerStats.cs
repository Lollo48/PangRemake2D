using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    PangEventManager m_eventManager;
    


    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
    }


   


}
