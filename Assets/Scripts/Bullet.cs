using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigidBody2D;
    [SerializeField] private float Bulletspeed;
    Vector2 moveDirection;



    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        moveDirection = Vector2.up * Bulletspeed;
        moveDirection.Normalize();
        moveDirection.x = 0;
        moveDirection = moveDirection * Bulletspeed;
        bulletRigidBody2D.velocity = moveDirection * Time.deltaTime;

    }


}
