using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Character_Moving : MonoBehaviour
{
    [SerializeField] private bool isOnCameraRightSide;
    [SerializeField] private bool isOnCameraLeftSide;
    [SerializeField] private float sideSpeed = 5f;
    [SerializeField] private float leftSideCamera = -8f;
    [SerializeField] private float rightSideCamera = 8f;

    private void Start()
    {
        isOnCameraRightSide = false;
        isOnCameraLeftSide = false;
    }

    void Update()
    {
        if (transform.position.x >= rightSideCamera)
        {
            isOnCameraRightSide = true;
        }

        if (transform.position.x <= leftSideCamera)
        {
            isOnCameraLeftSide = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !isOnCameraLeftSide)
        {
            transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && isOnCameraRightSide)
        {
            transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isOnCameraLeftSide)
        {
            transform.position = new Vector2(leftSideCamera, transform.position.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isOnCameraRightSide)
        {
            transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && isOnCameraLeftSide)
        {
            transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isOnCameraRightSide)
        {
            transform.position = new Vector2(rightSideCamera, transform.position.y);
        }
    }
}
