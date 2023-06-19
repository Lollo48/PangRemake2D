using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerManager : MonoBehaviour
{
    PlayerInputHandler m_inputHandler;
    Rigidbody2D m_playerRigidBody;
    Transform m_playerTransform;
    PlayerStateManager m_playerStateManager;
    PangEventManager eventManager;
    public float MovementSpeed;
    [HideInInspector]
    public bool CanShoot;
    [SerializeField]
    private float m_fireRate;
    [HideInInspector]
    public int Score;

    private void Awake()
    {
        m_playerRigidBody = GetComponent<Rigidbody2D>();
        m_playerTransform = GetComponent<Transform>();
        m_playerStateManager = new PlayerStateManager(m_playerTransform,m_playerRigidBody);
        m_playerStateManager.CurrentState = m_playerStateManager.ListOfStates[PlayerState.Idle];
        m_inputHandler = GetComponent<PlayerInputHandler>();
        eventManager = GameManager.instance.PangEventManager;
        eventManager.Registrer(EventName.GameOver, GameOver);
        CanShoot = true;
        Score = 0;

    }


  

    private void Update()
    {
        m_playerStateManager.CurrentState.OnUpdate();
        m_inputHandler.HandleAllInputs();
        UpdateStates();

    }
    
    /// <summary>
    /// reset shooting with deelay
    /// </summary>
    public void InvokeCanShoot()
    {
        Invoke("SetCanShoot", m_fireRate);
        
    }

    /// <summary>
    /// canShoot = true
    /// </summary>
    private void SetCanShoot()
    {
        CanShoot = true;
        
    }

    /// <summary>
    /// PlayerStateManager
    /// </summary>
    private void UpdateStates()
    {
        if (m_inputHandler.HorizontalInput != 0 && !m_inputHandler.IsShooting ) m_playerStateManager.ChangeState(PlayerState.Walk);
        else if(m_inputHandler.IsShooting && CanShoot ) m_playerStateManager.ChangeState(PlayerState.Shoot);
        else if (!m_inputHandler.IsShooting) m_playerStateManager.ChangeState(PlayerState.Idle);
        
    }

    /// <summary>
    /// GameOver Event
    /// </summary>
    private void GameOver()
    {
        Destroy(gameObject);
    }

}
