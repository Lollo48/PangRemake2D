using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float m_bulletspeed;
    



    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        transform.Translate(Vector3.up * m_bulletspeed * Time.deltaTime);

    }




}
