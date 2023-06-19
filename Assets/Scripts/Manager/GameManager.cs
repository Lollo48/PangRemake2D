using System.Collections;
using System.Collections.Generic;
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


}
