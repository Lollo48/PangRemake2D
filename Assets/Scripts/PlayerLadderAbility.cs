//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


///// <summary>
///// i don't know whether to keep this script here or put it all in the PlayerManager
///// </summary>
//public class PlayerLadderAbility : MonoBehaviour
//{


//    public float ladderSpeed;
//    [HideInInspector] public bool isLadder;
//    [HideInInspector] public bool isClimbing;



//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.layer == 3)
//        {
//            isLadder = true;

//        }
//    }


//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.layer == 3)
//        {
//            isLadder = false;
//            isClimbing = false;


//        }
//    }



//}
