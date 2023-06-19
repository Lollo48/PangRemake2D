//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LadderState : State<PlayerState>
//{


////NO TIME TO IMPLEMENT THAT FITURES 




//    PlayerStateManager m_playerStateManager;
//    Rigidbody2D playerRigidBody2D;
//    Transform m_playerTransform;
//    PlayerManager m_playerManager;
//    PlayerInputHandler m_playerInputManager;


//    public LadderState(PlayerState playerState, StateManager<PlayerState> stateManager = null) : base(playerState, stateManager)
//    {
//        m_playerStateManager = (PlayerStateManager)m_stateManager;
//        //Debug.Log(playerStateManager);
//    }

//    public override void OnEnter()
//    {
//        base.OnEnter();
//        GameManagerInstance();
//        if (playerRigidBody2D == null)
//        {
//            playerRigidBody2D = m_playerStateManager.PlayerRigidBody2D;
//            //Debug.Log( playerRigidBody2D);
//        }
//        if (m_playerTransform == null)
//        {
//            m_playerTransform = m_playerStateManager.PlayerTransform;
//            m_playerManager = m_playerStateManager.PlayerTransform.GetComponent<PlayerManager>();
//            //Debug.Log( playerTransform);
//        }
//    }


//    public override void OnUpdate()
//    {
//        base.OnUpdate();
//        LadderAbilityRun();
//    }

//    public override void OnExit()
//    {
//        base.OnExit();
//        m_playerStateManager.PlayerRigidBody2D.gravityScale = 1;
//        m_playerStateManager.PlayerRigidBody2D.velocity = new Vector2(0f, 0f);

//    }


//    private void GameManagerInstance()
//    {
//        m_playerInputManager = GameManager.instance.playerInputHandler;

//    }



//    private void LadderAbilityRun()
//    {
//        if (m_playerManager.isClimbing)
//        {
//            m_playerStateManager.PlayerRigidBody2D.gravityScale = 0;
//            float ladderVelocityY = m_playerInputManager.verticalInput * m_playerManager.ladderSpeed * Time.deltaTime;
//            m_playerStateManager.PlayerRigidBody2D.velocity = new Vector2(m_playerInputManager.horizontalInput, ladderVelocityY);
//        }


//    }


//}
