using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{

    [SerializeField] private float m_bulletspeed;
    new Rigidbody2D rigidbody2D;
    PlayerManager playerManager;
    Vector3 offset = new Vector3(0f, +2f, 0f);

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerManager = GameManager.instance.playerManager;
        
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
            playerManager.canShoot = true;
            balloonBounce.Destroyer();
            Disable(false);
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


