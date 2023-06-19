using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerManager : MonoBehaviour
{
    Animator m_animator;
    SpriteRenderer m_spriteRenderer;
    PangEventManager m_eventManager;

    private void Awake()
    {
        m_animator = GetComponentInChildren<Animator>();
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_eventManager = GameManager.instance.PangEventManager;
        m_eventManager.Registrer(EventName.HitPlayerEvent, UpdateHitAnimation);

    }


    /// <summary>
    /// update walk animation 
    /// i use this because i less time i take my old 3d function it works so 
    /// </summary>
    /// <param name="horizontalMovement"></param>
    /// <param name="isWalking"></param>
    public void UpdateAnimatorValues(float horizontalMovement,bool isWalking)
    {
        #region SNAPPED HORIZONTAL
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            m_spriteRenderer.flipX = false;

        }
        else if (horizontalMovement > 0.55f)
        {

            m_spriteRenderer.flipX = false;

        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {

            m_spriteRenderer.flipX = true;

        }
        else if (horizontalMovement < -0.55f)
        {

            m_spriteRenderer.flipX = true;

        }

        #endregion
        m_animator.SetBool("IsWalk", isWalking);

    }

    /// <summary>
    /// update animator Shooting 
    /// </summary>
    /// <param name="isShooting"></param>
    public void UpdateAnimatorShootingBool(bool isShooting)
    {
        m_animator.SetBool("isShooting", isShooting);
        
    }

    /// <summary>
    /// update hit animator 
    /// </summary>
    public void UpdateHitAnimation()
    {
        m_animator.SetTrigger("isHit");

    }

 




}
