using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject bulletPrefabs;
    private Vector3 offset = new Vector3(0, +1f,0f);




    public void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefabs, (transform.position + offset), Quaternion.identity);
        
    }
}
