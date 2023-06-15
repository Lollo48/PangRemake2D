using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    AnimationPlayerManager animationManager;
    public GameObject bulletPrefabs;
    public int fireRate;


    private void Awake()
    {
        animationManager = GetComponent<AnimationPlayerManager>();
    }





    public void Shooting(InputAction.CallbackContext callbackContext)
    {
        animationManager.UpdateAnimatorShootingBool(true);
        Instantiate(bulletPrefabs, transform.position, Quaternion.identity);

    }
}
