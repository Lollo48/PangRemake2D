using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    PangEventManager m_eventManager;
    PlayerManager m_playerManager;
    PlayerStats m_playerStats;
    GameManager m_gameManager;

    [SerializeField]
    private TextMeshProUGUI m_scoreText;
    [SerializeField]
    private Image[] m_lifeImage;
    [SerializeField]
    private GameObject m_pauseText;
    [SerializeField]
    private Image m_gameOverImage;
    [SerializeField]
    private GameObject m_winScene;
    [SerializeField]
    private TextMeshProUGUI m_finalScore;
    public Text Timer = null; //LAST MINUTE 


    private void Awake()
    {
        m_winScene.SetActive(false);
        m_eventManager = GameManager.instance.PangEventManager;
        m_playerManager = GameManager.instance.PlayerManager;
        m_gameManager = GameManager.instance;
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
        m_eventManager.Registrer(EventName.WinGame, WinScene);
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


    private void WinScene()
    {
        m_gameManager.CanGo = false;
        m_winScene.SetActive(true);

        ///add timer last minute
        // Count additional points for time and hp
        int pointsForTime = (int)m_gameManager.Timer * 100;
        int PointsLifeLeft = m_playerStats.Life;
        PointsLifeLeft = m_playerStats.Life * 100;
        m_finalScore.text =
                    "Score: " + m_playerManager.Score.ToString() +
                    "\nAdditional points for time: " + pointsForTime.ToString() +
                    "\nAdditional points for HP: " + PointsLifeLeft.ToString() +
                    "\nTotal score: " + (m_playerManager.Score + pointsForTime + PointsLifeLeft).ToString();

    }

   


}
