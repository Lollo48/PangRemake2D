using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float m_bulletspeed;
    new Rigidbody2D rigidbody2D;
    Vector3 offset = new Vector3(0f, +2f, 0f);
    PlayerManager playerManager;
    BallManager ballManager;

    private void Awake()
    {
        playerManager = GameManager.instance.playerManager;
        ballManager = GameManager.instance.ballManager;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void OnDisable()
    {
        transform.position = playerManager.transform.position - offset;
        
    }

    private void HandleMovement()
    {
        Vector2 moveDirection = Vector2.up * m_bulletspeed * Time.deltaTime;
        rigidbody2D.velocity = moveDirection;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out BalloonBounce balloonBounce))
        {
            Debug.Log("colpito");
            Disable(false);
            ballManager.lastPosition = balloonBounce.transform.position;
            balloonBounce.Destroyer();
            ballManager.destroyed = true;
            ballManager.SplitBall();
            ballManager.destroyed = false;

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (playerManager.canShoot) Disable(false);
    }

    private void Disable(bool isActive)
    {
        gameObject.SetActive(isActive);

    }


}


