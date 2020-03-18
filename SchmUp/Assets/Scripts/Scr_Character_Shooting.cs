using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Character_Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] shootingPos;
    private bool goodToShoot;
    public float bulletDelay;
    
    void Start()
    {
        goodToShoot = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && goodToShoot == true)
        {
            foreach (Transform shootingPos in shootingPos)
            {
                Instantiate(projectile, shootingPos.position, Quaternion.identity);
            }

            goodToShoot = false;
            StartCoroutine(BulletDelay());
        }
    }

    IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(bulletDelay);
        goodToShoot = true;
    }
}
