using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeapon : WeaponBase
{
    



    public override void Shoot(bool isActive)
    {
        m_bulletPrefabs.gameObject.SetActive(isActive);
    }



}
