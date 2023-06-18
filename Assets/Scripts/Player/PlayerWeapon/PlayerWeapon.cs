using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject BulletPrefabs;


    public void Shoot(bool isActive)
    {
        BulletPrefabs.gameObject.SetActive(isActive);
    }



}
