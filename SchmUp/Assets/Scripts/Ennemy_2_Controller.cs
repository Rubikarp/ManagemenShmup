using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_2_Controller : MonoBehaviour
{
    private Rigidbody2D ennemy2;
    private GameObject player;
    private bool readyToDash;
    public float DashInitialisationRange = 15f;
    public float DashSpeed = 10f;
    private Vector2 Distance;
    private Transform Ennemy;
    private float Delai;
    public float OriginDelai;

    // Start is called before the first frame update
    void Start()
    {
        ennemy2 = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");



        readyToDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToDash == true && Vector2.Distance(transform.position, player.transform.position) < DashInitialisationRange)
        {
            readyToDash = false;
            Ennemy = player.transform;
            //Vector2.Distance(transform.position, player.transform.position);
            //Vector2 Target = player.transform.position;
            //ennemy2.velocity = Distance * DashInitialisationRange;
        }
        else if(readyToDash == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ennemy.position, DashSpeed * Time.deltaTime);
            if(transform.position == Ennemy.position)
            {
                if(Delai > 0)
                {
                    Delai -= Time.deltaTime;
                }
                else if (Delai <= 0)
                {
                    Delai = OriginDelai;
                    readyToDash = true;
                }
               
            }
        }
    }
}
