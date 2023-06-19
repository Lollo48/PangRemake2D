using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BalloonBounceBase : MonoBehaviour
{

    protected Rigidbody2D m_rigidbody2D;



    protected virtual void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

    }

    protected virtual void FixedUpdate()
    {
        HandleMouvement();
    }
    protected virtual void HandleMouvement() { }
    public virtual void Destroyer()
    {
        Destroy(gameObject);
        //potenziamenti se ho tempo
    }
    protected virtual void CollisionEnter(Collision2D collision) { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnter(collision);
    }

   
}
