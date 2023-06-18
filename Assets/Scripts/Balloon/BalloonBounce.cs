using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBounce : BalloonBounceBase
{
    public float BounceHorizontalForce;
    public float BounceVerticalForce;
    public float JumpHeight;
    Vector3 m_lastVelocity;
    PangEventManager eventManager;
    public BallSize BallSize;
    BallManager ballManager;
    Vector3 offset = new Vector3(0, 3, 0);

    protected override void Awake()
    {
        base.Awake();
        ballManager = GameManager.instance.BallManager;
        eventManager = GameManager.instance.PangEventManager;
        BounceHorizontalForce += 9.8f * 25f * Time.deltaTime;
        BounceVerticalForce += 9.8f * 25f * Time.deltaTime;
    }

    private void Start()
    {
        ChoseSize(this, BallSize);
    }

    protected override void HandleMouvement()
    {
        base.HandleMouvement();
        m_lastVelocity = m_rigidbody2D.velocity;
    }

    protected override void CollisionEnter(Collision2D collision)
    {
        base.CollisionEnter(collision);
        var speed = m_lastVelocity.magnitude;
        var direction = Vector3.Reflect(m_lastVelocity.normalized, collision.contacts[0].normal);

        if (collision.gameObject.layer == 7)
        {
            m_rigidbody2D.velocity = new Vector2(direction.x * Mathf.Max(speed, 0f), JumpHeight * Time.deltaTime);
        }
        else
        {
            m_rigidbody2D.velocity = new Vector2(direction.x * Mathf.Max(speed, 0f), direction.y * Mathf.Max(speed, 0f));
        }

        if (collision.transform.TryGetComponent(out PlayerStats playerStats))
        {
            Debug.Log("player");
            ballManager.LastPosition = transform.position + offset;
            ballManager.SetDestroyerBool(true);
            ballManager.SplitBall(BallSize);
            ballManager.SetDestroyerBool(false);
            Destroyer();
            eventManager.TriggerEvent(EventName.HitPlayerEvent);
        }
    }


    public void ChoseSize(BalloonBounce ball1,BallSize ballSize)
    { 
        switch (ballSize)
        {
            case BallSize.L:
                ball1.transform.localScale = new Vector3(5f, 5f, 5f);
                break;
            case BallSize.M:
                ball1.transform.localScale = new Vector3(4f, 4f, 4f);
                break;
            case BallSize.S:
                ball1.transform.localScale = new Vector3(3f, 3f, 3f);
                break;
            case BallSize.XS:
                ball1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            default:
                break;
        }

    }


    /// <summary>
    /// bug fix
    /// </summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        BugFixAt3AM();
    }

    /// <summary>
    /// some thimes realy realy unusual the ball velocity is 0 , i can't test because i can't reproduce the bug 
    /// i hope this will fix that bug 
    /// </summary>
    private void BugFixAt3AM()
    {
        if (transform.position.y < -4)
        {
            Debug.Log("sono minore");
            var speed = m_lastVelocity.magnitude;
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x * Mathf.Max(speed, 0f), m_rigidbody2D.velocity.y * Mathf.Max(speed, 0f));
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