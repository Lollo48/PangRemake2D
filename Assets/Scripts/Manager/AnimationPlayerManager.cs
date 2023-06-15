using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerManager : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }


    public void UpdateAnimatorValues(float horizontalMovement,bool isWalking)
    {
        #region SNAPPED HORIZONTAL
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            sprite.flipX = false;

        }
        else if (horizontalMovement > 0.55f)
        {

            sprite.flipX = false;

        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {

            sprite.flipX = true;

        }
        else if (horizontalMovement < -0.55f)
        {

            sprite.flipX = true;

        }

        #endregion
        animator.SetBool("IsWalk", isWalking);

    }


    public void UpdateAnimatorShootingBool(bool isShooting)
    {
        animator.SetBool("isShooting", isShooting);
        
    }

    


}
