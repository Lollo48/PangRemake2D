using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{

    /// <summary>
    /// First time that i prove to implement audio source on a project so i don't know if this is the best practies 
    /// </summary>
    PangEventManager m_eventManager;

    [SerializeField]
    private AudioSource m_audioSource;
    [SerializeField]
    private AudioSource m_audioSourceDefaultSong;
    [SerializeField]
    private AudioSource m_audioSourceWinSong;
    [SerializeField]
    private AudioClip m_hitPlayer, m_score,m_shoot,m_destroyBullet,m_playerDeath;



    private void Awake()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        m_eventManager.Registrer(EventName.HitPlayerEvent, HittedPlayerAudio);
        m_eventManager.Registrer(EventName.ScoreEvent, HitBalloon);
        m_eventManager.Registrer(EventName.DestroyBulletEvent, DestroyBullet);
        m_eventManager.Registrer(EventName.ShootEvent, Shoot);
        m_eventManager.Registrer(EventName.GameOver, PlayerDeath);
        m_eventManager.Registrer(EventName.WinGame, WinAudio);
    }

    private void Start()
    {
        m_audioSourceDefaultSong.enabled = true;
        m_audioSourceWinSong.enabled = false;
    }
    /// <summary>
    /// hit player 
    /// </summary>
    private void HittedPlayerAudio()
    {
        m_audioSource.clip = m_hitPlayer;
        m_audioSource.Play();
    }

    /// <summary>
    /// hit balloon
    /// </summary>
    private void HitBalloon()
    {
        m_audioSource.clip = m_score;
        m_audioSource.Play();
    }

    /// <summary>
    /// destroyBullet
    /// </summary>
    private void DestroyBullet()
    {
        m_audioSource.clip = m_destroyBullet;
        m_audioSource.Play();
    }

    /// <summary>
    /// shoot 
    /// </summary>
    private void Shoot()
    {
        m_audioSource.clip = m_shoot;
        m_audioSource.Play();
    }

    /// <summary>
    /// Player die 
    /// </summary>
    private void PlayerDeath()
    {
        m_audioSource.clip = m_playerDeath;
        m_audioSource.Play();

    }

    /// <summary>
    /// WinAudio
    /// </summary>
    private void WinAudio()
    {
        m_audioSourceDefaultSong.enabled = false;
        m_audioSourceWinSong.enabled = true;

    }

}
