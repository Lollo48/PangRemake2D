using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    PangEventManager eventManager;

    public AudioSource audioSource;
    public AudioSource audioSourceDefaultSong;
    public AudioClip hitPlayer, scoreEvent,shoot,destroyBullet,PlayerDeathAudio;



    private void Awake()
    {
        eventManager = GameManager.instance.PangEventManager;
        eventManager.Registrer(EventName.HitPlayerEvent, HittedPlayerAudio);
        eventManager.Registrer(EventName.ScoreEvent, HittedBallon);
        eventManager.Registrer(EventName.DestroyBulletEvent, DestroyBullet);
        eventManager.Registrer(EventName.ShootEvent, Shoot);
        eventManager.Registrer(EventName.GameOver, PlayerDeath);
    }

    private void HittedPlayerAudio()
    {
        audioSource.clip = hitPlayer;
        audioSource.Play();
    }

    private void HittedBallon()
    {
        audioSource.clip = scoreEvent;
        audioSource.Play();
    }

    private void DestroyBullet()
    {
        audioSource.clip = destroyBullet;
        audioSource.Play();
    }


    private void Shoot()
    {
        audioSource.clip = shoot;
        audioSource.Play();
    }

    private void PlayerDeath()
    {
        audioSource.clip = PlayerDeathAudio;
        audioSource.Play();

    }


}
