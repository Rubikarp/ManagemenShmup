using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Projectile_Behaviour : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet.velocity = new Vector2(0, speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Scr_Enemy_Death>().health -= damage;
            Destroy(gameObject);
        }
    }
}
