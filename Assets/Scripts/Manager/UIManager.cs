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
    public Image[] LifeImage;
    public TextMeshProUGUI pauseText;
    public Image gameOverImage;
    


    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_playerManager = GameManager.instance.PlayerManager;
        m_playerStats = m_playerManager.transform.GetComponent<PlayerStats>();
    }

    private void Start()
    {
        m_eventManager.Registrer(EventName.ScoreEvent, UpdateScore);
        m_eventManager.Registrer(EventName.HitPlayerEvent, HitPlayerUI);
        m_eventManager.Registrer(EventName.GamePause, GamePause);
        m_eventManager.Registrer(EventName.GameResume, ResumeGamePause);
        m_eventManager.Registrer(EventName.GameOver, GameOver);
    }

    private void UpdateScore()
    {
        m_scoreText.text = m_playerManager.Score.ToString();
        
    }

    private void HitPlayerUI()
    {
        if (m_playerStats.PlayerLife == 2) LifeImage[0].enabled = false;
        else if (m_playerStats.PlayerLife == 1) LifeImage[1].enabled = false;
        else
        {
            LifeImage[2].enabled = false;
            m_eventManager.TriggerEvent(EventName.GameOver);
        }
    }

    private void GamePause()
    {
        pauseText.gameObject.SetActive(true);

    }

    private void ResumeGamePause()
    {
        pauseText.gameObject.SetActive(false);
    }


    private void GameOver()
    {
        gameOverImage.gameObject.SetActive(true);

    }


}
