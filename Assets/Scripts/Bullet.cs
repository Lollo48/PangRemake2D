using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float m_bulletspeed;
    new Rigidbody2D rigidbody2D;
    public LayerMask layerMask;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down *10f, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * 10f, Color.red);
        Debug.Log("hitt " + hit.collider.gameObject);

        //if (hit.transform.TryGetComponent(out BalloonBounce balloonBounce))
        //{
        //    Debug.Log("raycast2d colpito il pallone");
        //    balloonBounce.Destroyer();
        //}

   

    }
    private void FixedUpdate()
    {
        HandleMovement();
        Invoke("Destroyer", 3f);

        
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
