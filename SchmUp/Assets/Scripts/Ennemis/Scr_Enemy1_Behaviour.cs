using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy1_Behaviour : MonoBehaviour
{
    public GameObject _pewpew;
    private bool _movingRight;
    private bool _movingDown;
    public float _verticalSpeed;
    public float _horizontalSpeed;
    private float _shootDelay;
    public float _shootDelayOrigin;

    public float _maxSide;
    public float _maxHeight;


    void Start()
    {
        _movingRight = true;
        _movingDown = true;
        _shootDelay = _shootDelayOrigin;
    }

    void Update()
    {
        if (_movingRight == true && _movingDown == true)
        {
            transform.position = new Vector2(transform.position.x + (_horizontalSpeed * Time.deltaTime), transform.position.y - (_verticalSpeed * Time.deltaTime));
        }
        else if (_movingRight == false && _movingDown == true)
        {
            transform.position = new Vector2(transform.position.x - (_horizontalSpeed * Time.deltaTime), transform.position.y - (_verticalSpeed * Time.deltaTime));
        }
        else if (_movingRight == true && _movingDown == false)
        {
            transform.position = new Vector2(transform.position.x + (_horizontalSpeed * Time.deltaTime), transform.position.y + (_verticalSpeed * Time.deltaTime));
        }
        else if (_movingRight == false && _movingDown == false)
        {
            transform.position = new Vector2(transform.position.x - (_horizontalSpeed * Time.deltaTime), transform.position.y + (_verticalSpeed * Time.deltaTime));
        }


        if (transform.position.x >= _maxSide)
        {
            _movingRight = false;
        }
        if (transform.position.x <= -_maxSide)
        {
            _movingRight = true;
        }
        if (transform.position.y >= _maxHeight)
        {
            _movingDown = true;
        }
        if (transform.position.y <= -_maxHeight)
        {
            _movingDown = false;
        }


        if (_shootDelay > 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        else if (_shootDelay <= 0)
        {
            Instantiate(_pewpew, transform.position, Quaternion.identity);

            _shootDelay = _shootDelayOrigin;
        }
    }
}


