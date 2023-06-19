using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    PangEventManager m_eventManager;
    PlayerManager m_playerManager;
    PlayerStats m_playerStats;

    [SerializeField]
    private TextMeshProUGUI m_scoreText;
    [SerializeField]
    private Image[] m_lifeImage;
    [SerializeField]
    private TextMeshProUGUI m_pauseText;
    [SerializeField]
    private Image m_gameOverImage;
    

  
    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_playerManager = GameManager.instance.PlayerManager;
        m_playerStats = m_playerManager.transform.GetComponent<PlayerStats>();
    }


    /// <summary>
    /// register to all events
    /// </summary>
    private void Start()
    {
        m_eventManager.Registrer(EventName.ScoreEvent, UpdateScore);
        m_eventManager.Registrer(EventName.HitPlayerEvent, HitPlayerUI);
        m_eventManager.Registrer(EventName.GamePause, GamePause);
        m_eventManager.Registrer(EventName.GameResume, ResumeGamePause);
        m_eventManager.Registrer(EventName.GameOver, GameOver);
    }

    /// <summary>
    /// Update score with playerManager Score 
    /// </summary>
    private void UpdateScore()
    {
        m_scoreText.text = m_playerManager.Score.ToString();
        
    }


    /// <summary>
    /// chose the right heart image to remove
    /// </summary>
    private void HitPlayerUI()
    {
        if (m_playerStats.Life == 2) m_lifeImage[0].enabled = false;
        else if (m_playerStats.Life == 1) m_lifeImage[1].enabled = false;
        else
        {
            m_lifeImage[2].enabled = false;
            m_eventManager.TriggerEvent(EventName.GameOver);
        }
    }


    /// <summary>
    /// gamePause
    /// </summary>
    private void GamePause()
    {
        m_pauseText.gameObject.SetActive(true);

    }

    /// <summary>
    /// resumeGame 
    /// </summary>
    private void ResumeGamePause()
    {
        m_pauseText.gameObject.SetActive(false);
    }

    /// <summary>
    /// gameOver
    /// </summary>
    private void GameOver()
    {
        m_gameOverImage.gameObject.SetActive(true);

    }


}
