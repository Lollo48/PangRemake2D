using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float m_bulletspeed;
    new Rigidbody2D rigidbody2D;
    PlayerInputHandler playerInputHandler;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerInputHandler = GameManager.instance.playerInputHandler;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        Invoke("Destroyer", 4f);
    }

    private void HandleMovement()
    {
        Vector2 moveDirection = Vector2.up * m_bulletspeed * Time.deltaTime;
        rigidbody2D.velocity = moveDirection;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out BalloonBounce balloonBounce))
        {
            Debug.Log("colpito");
            balloonBounce.Destroyer();
            Destroyer();
        }
    }


    private void Destroyer()
    {
        Destroy(gameObject);

    }

}
