using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Projectile_Behaviour : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D bullet;

    public float _maxTravellingDistance = 10f;
    private Vector3 _startPos = Vector3.zero;


    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        _startPos = this.transform.position;

    }

    void Update()
    {
        bullet.velocity = new Vector2(0, speed);

        if (Vector2.Distance(this.transform.position, _startPos) > _maxTravellingDistance)
        {
            Destroy(gameObject);
        }
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
