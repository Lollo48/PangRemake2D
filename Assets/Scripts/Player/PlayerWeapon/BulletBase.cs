using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BulletBase : MonoBehaviour
{

    protected Rigidbody2D m_rigidbody2D;
    protected PlayerManager m_playerManager;
    protected BallManager m_ballManager;

    protected virtual void Awake()
    {
        m_playerManager = GameManager.instance.PlayerManager;
        m_ballManager = GameManager.instance.BallManager;
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        HandleMovement();
    }


    private void OnDisable()
    {
        WeaponPositionAfterDisable();
    }

    protected virtual void OnDisableGameObject(bool disable)
    {
        gameObject.SetActive(disable);

    }

    protected virtual void HandleMovement() { }



    protected virtual void CollisionEnter(Collision2D collision2D) { } 
    protected virtual void CollisionStay(Collision2D collision2D) { }
    protected virtual void WeaponPositionAfterDisable() { }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnter(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollisionStay(collision);
    }

   

}
