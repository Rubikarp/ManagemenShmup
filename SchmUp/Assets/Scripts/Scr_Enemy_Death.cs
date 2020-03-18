using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy_Death : MonoBehaviour
{
    public float health;

    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
