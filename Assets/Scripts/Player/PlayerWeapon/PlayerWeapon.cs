using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject bulletPrefabs;


    public void Shoot(bool isActive)
    {
        bulletPrefabs.gameObject.SetActive(isActive);
    }



}
