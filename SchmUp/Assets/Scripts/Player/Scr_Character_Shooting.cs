using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Character_Shooting : MonoBehaviour
{
    private Scr_InputManager _input = null;

    public GameObject projectile;
    public Transform[] shootingPos;
    private bool goodToShoot = true;
    public float bulletDelay;
    
    void Start()
    {
        _input = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scr_InputManager>();
    }

    void Update()
    {
        if (_input._ShootInput && goodToShoot == true)
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
