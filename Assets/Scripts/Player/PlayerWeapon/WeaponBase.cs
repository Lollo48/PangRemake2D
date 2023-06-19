using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_bulletPrefabs;




    public virtual void Shoot(bool isActive) { }




}
