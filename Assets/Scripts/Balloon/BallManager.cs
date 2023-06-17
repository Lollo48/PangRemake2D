using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BalloonBounce ballPrefab;
    public Transform ballSpawner;
    public bool destroyed ;
    public Vector3 lastPosition;
    public BallSize ballSize;


    private void Awake()
    {
        ballSize = BallSize.L;
        destroyed = false;
        BalloonBounce ball1 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        SetRBForceDirection(ball1, -ball1.bounceverticalForce, ball1.bounceHorizontalForce);


    }

   


    private void SetRBForceDirection(BalloonBounce ball, float verticalForce, float horizontalForce)
    {
        ball.rigidbody2D.AddForce(new Vector2(verticalForce, horizontalForce));

    }


    public void BreakBall()
    {
        if (destroyed)
        {

            BalloonBounce ball1 = Instantiate(ballPrefab, lastPosition, Quaternion.identity);
            BalloonBounce ball2 = Instantiate(ballPrefab, lastPosition, Quaternion.identity);

            ChoseSize(ball1,ball2);

            SetRBForceDirection(ball1, ball1.bounceverticalForce, ball1.bounceHorizontalForce);
            SetRBForceDirection(ball2, -ball2.bounceverticalForce, ball1.bounceHorizontalForce);

        }
            
    }


    private void ChoseSize(BalloonBounce ball1,BalloonBounce ball2)
    {
        
        switch (ballSize)
        {
            case BallSize.L :
                {
                    ball1.transform.localScale = new Vector3(4f, 4f, 4f);
                    ball2.transform.localScale = new Vector3(4f, 4f, 4f);
                    ballSize = BallSize.M;
                    break;
                }
                
            case BallSize.M :
                {
                    ball1.transform.localScale = new Vector3(3f, 3f, 3f);
                    ball2.transform.localScale = new Vector3(3f, 3f, 3f);
                    ballSize = BallSize.S;
                    break;
                }
            case BallSize.S :
                {
                    ball1.transform.localScale = new Vector3(2f, 2f, 2f);
                    ball2.transform.localScale = new Vector3(2f, 2f, 2f);
                    ballSize = BallSize.XS;
                    break;
                } 
            case BallSize.XS:
                {
                    ball1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    ball2.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    ball1.Destroyer();
                    ball2.Destroyer();
                    break;
                }
            default:    
                break;
        }

    }





}

public enum BallSize
{
    L,
    M,
    S,
    XS
}




