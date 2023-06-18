using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletBase
{

    [SerializeField] private float m_bulletspeed;
    Vector3 m_offset = new Vector3(0f, +2f, 0f);
    PangEventManager m_eventManager;


    private void OnEnable()
    {
        m_eventManager = GameManager.instance.PangEventManager;
        transform.rotation = Quaternion.identity;
    }

    protected override void WeaponPositionAfterDisable()
    {
        base.WeaponPositionAfterDisable();
        transform.position = m_playerManager.transform.position - m_offset;
    }

    protected override void HandleMovement()
    {
        Vector2 moveDirection = Vector2.up * m_bulletspeed * Time.deltaTime;
        m_rigidbody2D.velocity = moveDirection;

    }


    protected override void CollisionEnter(Collision2D collision2D)
    {
        base.CollisionEnter(collision2D);
        if (collision2D.transform.TryGetComponent(out BalloonBounce balloonBounce))
        {
            Debug.Log("colpito");
            m_playerManager.Score += m_ballManager.BallScore;
            m_eventManager.TriggerEvent(EventName.ScoreEvent);
            OnDisableGameObject(false);
            m_eventManager.TriggerEvent(EventName.DestroyBulletEvent);
            m_ballManager.LastPosition = balloonBounce.transform.position;
            m_ballManager.SetDestroyerBool(true);
            m_ballManager.SplitBall(balloonBounce.BallSize);
            m_ballManager.SetDestroyerBool(false);
            balloonBounce.Destroyer();
        }

    }

    protected override void CollisionStay(Collision2D collision2D)
    {
        base.CollisionStay(collision2D);
        if (m_playerManager.CanShoot)
        {
            OnDisableGameObject(false);
            m_eventManager.TriggerEvent(EventName.DestroyBulletEvent);
        }
    }

  

}


