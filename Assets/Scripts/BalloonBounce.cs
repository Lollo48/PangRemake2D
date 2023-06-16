using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBounce : MonoBehaviour
{

	new Rigidbody2D rigidbody2D;
    Vector3 lastVelocity;
    public float bounceHorizontalForce;
    public float bounceverticalForce;
    public float jumpHeight;

    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        bounceHorizontalForce += 9.8f * 25f * Time.deltaTime;
        bounceverticalForce += 9.8f * 25f * Time.deltaTime;
        rigidbody2D.AddForce(new Vector2(bounceverticalForce, bounceHorizontalForce));
    }

    private void FixedUpdate()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        if (collision.gameObject.layer == 7)
        {
            rigidbody2D.velocity = new Vector2(direction.x * Mathf.Max(speed, 0f), jumpHeight * Time.deltaTime);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(direction.x * Mathf.Max(speed, 0f), direction.y * Mathf.Max(speed, 0f));
        }

    }

 
}



