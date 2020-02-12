using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Character_Shooting : MonoBehaviour
{
    public GameObject projectile;
    private bool goodToShoot;
    public float bulletDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        goodToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && goodToShoot == true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
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
