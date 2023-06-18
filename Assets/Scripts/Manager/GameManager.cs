using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public AnimationPlayerManager AnimationManager;
    public PlayerInputHandler PlayerInputHandler;
    public PlayerManager PlayerManager;
    public BallManager BallManager;
    public PangEventManager PangEventManager;

    private void OnEnable()
    {
        if (Time.timeScale == 0) Resume();
    }

    private void Start()
    {
        PangEventManager.Registrer(EventName.GamePause, Pause);
        PangEventManager.Registrer(EventName.GameResume, Resume);
        PangEventManager.Registrer(EventName.GameOver, Pause);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0) PangEventManager.TriggerEvent(EventName.GameResume);
            else PangEventManager.TriggerEvent(EventName.GamePause);

        }
    }
    private void Pause()
	{
		Time.timeScale = 0;
		
	}

    private void Resume()
	{
		Time.timeScale = 1;
		
	}


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
