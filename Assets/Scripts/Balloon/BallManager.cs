using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{


    public BalloonBounce ballPrefab;
	public Transform BallSpawner;
    private bool destroyed;
    private int MaxBallonSize = 4;


    private void Awake()
    {
        BalloonBounce ball1 = Instantiate(ballPrefab, BallSpawner.position, Quaternion.identity);
        BalloonBounce ball2 = Instantiate(ballPrefab, BallSpawner.position, Quaternion.identity);
        SetRBForceDirection(ball1, -ball1.bounceverticalForce, ball1.bounceHorizontalForce);
        SetRBForceDirection(ball2, ball1.bounceverticalForce, ball2.bounceHorizontalForce);
    }


    private void SetRBForceDirection(BalloonBounce ball, float verticalForce, float horizontalForce)
    {
        ball.rigidbody2D.AddForce(new Vector2(verticalForce, horizontalForce));

    }


    public void BreakBall()
    {
        int firstBallonSize = 0;
        if (destroyed)
            return;

        // If the ball isn't the smallest size, create two new balls
        if (firstBallonSize < MaxBallonSize)
        {
            BalloonBounce ball1 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            BalloonBounce ball2 = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            

            SetRBForceDirection(ball1, -ball1.bounceverticalForce, ball1.bounceHorizontalForce);
            SetRBForceDirection(ball2, ball1.bounceverticalForce, ball2.bounceHorizontalForce);

            firstBallonSize +=1;
        }
        
        // Destroy the ball
        Destroy(gameObject);
        destroyed = true;


    }

 





}


enum BallSize
{

}


