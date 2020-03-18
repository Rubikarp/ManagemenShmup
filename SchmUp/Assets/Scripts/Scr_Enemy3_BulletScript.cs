using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy3_BulletScript : MonoBehaviour
{
    public float _verticalMovement;
    public float _horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (_horizontalMovement * Time.deltaTime), transform.position.y + (_verticalMovement * Time.deltaTime));
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
