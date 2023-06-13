using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    InputManager InputManager;
    Vector2 moveDirection;
    Rigidbody2D playerRigidBody;
    public float movementSpeed;



    private void Awake()
    {
        InputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody2D>();

    }

    public void HandleAllMouvement()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        //moveDirection = InputManager.horizontalInput * movementSpeed;
        //playerRigidBody.velocity = new Vector2(moveDirection, 0);

        moveDirection = Vector2.right * InputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;
        playerRigidBody.velocity = moveDirection * Time.deltaTime;

    }




}
