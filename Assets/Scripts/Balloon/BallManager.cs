using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BalloonBounce ballPrefab;
    public Transform ballSpawner;
    public bool destroyed ;
    public Vector3 lastPosition;
    public int ballSize;


    private void Awake()
    {
        
        destroyed = false;
        BalloonBounce ball1 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        SetRBForceDirection(ball1, -ball1.bounceverticalForce, ball1.bounceHorizontalForce);


    }

   


    private void SetRBForceDirection(BalloonBounce ball, float verticalForce, float horizontalForce)
    {
        ball.rigidbody2D.AddForce(new Vector2(verticalForce, horizontalForce));

    }


    public void SplitBall()
    {
        if (destroyed)
        {

            BalloonBounce ball1 = Instantiate(ballPrefab, lastPosition, Quaternion.identity);
            BalloonBounce ball2 = Instantiate(ballPrefab, lastPosition, Quaternion.identity);

            ball1.ChoseSize(ball1);
          
            ball2.ChoseSize(ball2);

            SetRBForceDirection(ball1, ball1.bounceverticalForce, ball1.bounceHorizontalForce);
            SetRBForceDirection(ball2, -ball2.bounceverticalForce, ball1.bounceHorizontalForce);

        }
            
    }


    

}






