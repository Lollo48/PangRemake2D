using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// the reference for all for the Singleton<GameManager>
    /// </summary>
    public AnimationPlayerManager AnimationManager;
    public PlayerInputHandler PlayerInputHandler;
    public PlayerManager PlayerManager;
    public BallManager BallManager;
    public PangEventManager PangEventManager;
    public UIManager UIManager;
    public float Timer;// LAST MINUTE
    [HideInInspector]
    public bool CanGo;
   

    private void OnEnable()
    {
        if (Time.timeScale == 0) Resume();
        else Time.timeScale = 1;
        CanGo = true;
    }

    private void Start()
    {
        PangEventManager.Registrer(EventName.GamePause, Pause);
        PangEventManager.Registrer(EventName.GameResume, Resume);
        PangEventManager.Registrer(EventName.GameOver, Pause);
        //LAST MINUTE
        if (GameManager.instance.UIManager.Timer != null)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Timer);
            GameManager.instance.UIManager.Timer.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

    }

    /// <summary>
    /// i use the old inputsystem here because i don't have much time 
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0) PangEventManager.TriggerEvent(EventName.GameResume);
            else PangEventManager.TriggerEvent(EventName.GamePause);

        }
        //LAST MINUTE IT'S HORRIBLE I DON'T LIKE THE COMPARETAG
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            PlayerManager.gameObject.SetActive(false);
            PangEventManager.TriggerEvent(EventName.WinGame);
        }
        TimerFunction();
    }

    /// <summary>
    /// pause the game 
    /// </summary>
    private void Pause()
	{
		Time.timeScale = 0;
		
	}

    /// <summary>
    /// resume the game 
    /// </summary>
    private void Resume()
	{
		Time.timeScale = 1;
		
	}

    /// <summary>
    /// restart the game 
    /// </summary>
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }



    /// <summary>
    /// Timer LAST MINUTE I DON'T LIKE IT
    /// </summary>
    private void TimerFunction()
    {
        if (CanGo)
        {
            if (Timer != Mathf.Infinity)
            {
                Timer -= Time.deltaTime;

                if (Timer <= 0f)
                {
                    Timer = 0f;
                    PangEventManager.TriggerEvent(EventName.GameOver);
                }

                if (GameManager.instance.UIManager.Timer != null)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(Timer);
                    GameManager.instance.UIManager.Timer.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                }
            }
        }
        

    }

}
