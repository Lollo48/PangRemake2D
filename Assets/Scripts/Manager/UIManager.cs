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



    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_playerManager = GameManager.instance.PlayerManager;
        m_playerStats = m_playerManager.transform.GetComponent<PlayerStats>();
    }

    private void Start()
    {
        m_eventManager.Registrer(EventName.ScoreEvent, UpdateScore);
        m_eventManager.Registrer(EventName.HitPlayerEvent, UpdateLifeImage);
    }

    public void UpdateScore()
    {
        m_scoreText.text = m_playerManager.Score.ToString();
        
    }

    public void UpdateLifeImage()
    {
        if (m_playerStats.PlayerLife == 2) LifeImage[0].enabled = false;
        else if (m_playerStats.PlayerLife == 1) LifeImage[1].enabled = false;
        else LifeImage[2].enabled = false;
    }

    public void GameOver()
    {


    }


}
