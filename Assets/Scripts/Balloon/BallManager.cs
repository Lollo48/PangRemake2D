using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    private BalloonBounce[] m_initialBallPrefabSpawn;
    [SerializeField]
    private BalloonBounce m_ballPrefab;
    [SerializeField]
    private Transform m_ballSpawner;
    [HideInInspector]
    public bool Destroyed;
    [HideInInspector]
    public Vector3 LastPosition;
    public int BallScore;
    public float TimeBeforeAnotherBallSpawn;


    private void Awake()
    {
        StartCoroutine(InitialSpawn());
    }


    /// <summary>
    /// initial ball spawn 
    /// use the coroutine to make a delay to make the game more unpredictable
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitialSpawn()
    {
        Destroyed = false;
        for (int i = 0; i < m_initialBallPrefabSpawn.Length; i++)
        {
            if (m_initialBallPrefabSpawn.Length == 1)
            {
                BalloonBounce ball1 = InitialInstantiate(m_initialBallPrefabSpawn, m_ballSpawner, i);
                SetRBForceDirection(ball1, -ball1.BounceVerticalForce, ball1.BounceHorizontalForce);
                ball1.ChoseSize(ball1, ball1.BallSize);
                //Debug.Log("initial ball size " + ball1.BallSize);
            }
            else
            {
                if (i % 2 == 0)
                {
                    BalloonBounce ball1 = InitialInstantiate(m_initialBallPrefabSpawn, m_ballSpawner, i);
                    SetRBForceDirection(ball1, -ball1.BounceVerticalForce, ball1.BounceHorizontalForce);
                    ball1.ChoseSize(ball1, ball1.BallSize);
                }
                else
                {
                    BalloonBounce ball1 = InitialInstantiate(m_initialBallPrefabSpawn, m_ballSpawner, i);
                    SetRBForceDirection(ball1, ball1.BounceVerticalForce, ball1.BounceHorizontalForce);
                    ball1.ChoseSize(ball1, ball1.BallSize);
                }

            }
            yield return new WaitForSeconds(TimeBeforeAnotherBallSpawn);

        }

    }

    /// <summary>
    /// first Instantiate function
    /// </summary>
    /// <param name="initialballPrefabSpawn"></param>
    /// <param name="position"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private BalloonBounce InitialInstantiate(BalloonBounce[] initialballPrefabSpawn, Transform position, int index)
    {
        BalloonBounce balloonBounce = Instantiate(initialballPrefabSpawn[index], position.position, Quaternion.identity);

        return balloonBounce;
    }

    /// <summary>
    /// set the first rigidbody velocity when ball spawn 
    /// </summary>
    /// <param name="ball"></param>
    /// <param name="verticalForce"></param>
    /// <param name="horizontalForce"></param>
    private void SetRBForceDirection(BalloonBounce ball, float verticalForce, float horizontalForce)
    {
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(verticalForce, horizontalForce));

    }


    /// <summary>
    /// Instantiate the new ball after destroy the first one 
    /// this function decide how much ball will spawn and the own size 
    /// </summary>
    /// <param name="ballSize"></param>
    public void SplitBall(BallSize ballSize)
    {

        if (Destroyed)
        {
            if (ballSize == BallSize.XS) return;

            BalloonBounce ball1 = Instantiate(m_ballPrefab, LastPosition, Quaternion.identity);
            BalloonBounce ball2 = Instantiate(m_ballPrefab, LastPosition, Quaternion.identity);

            ball1.BallSize = ballSize + 1;
            ball2.BallSize = ballSize + 1;
            ////Debug.Log("Ball 1 size " + ball1.BallSize);
            ////Debug.Log("Ball 2 size " + ball2.BallSize);

            //ball1.ChoseSize(ball1, ballSize);
            //ball2.ChoseSize(ball2, ballSize);

            SetRBForceDirection(ball1, ball1.BounceVerticalForce, ball1.BounceHorizontalForce);
            SetRBForceDirection(ball2, -ball2.BounceVerticalForce, ball1.BounceHorizontalForce);

        }

    }


    /// <summary>
    /// Destroier function
    /// </summary>
    /// <param name="canDestroy"></param>
    public void SetDestroyerBool(bool canDestroy)
    {
        Destroyed = canDestroy;
    }
}







