using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    PangEventManager m_eventManager;
    BallManager m_ballManager;
    [SerializeField]
    private TextMeshProUGUI m_scoreText;
    PlayerManager playerManager;


    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_ballManager = GameManager.instance.BallManager;
        playerManager = GameManager.instance.PlayerManager;
    }

    private void Start()
    {
        m_eventManager.Registrer(EventName.UpdateScore, UpdateScore);
    }

    public void UpdateScore()
    {
        m_scoreText.text = playerManager.Score.ToString();
        
    }

}
