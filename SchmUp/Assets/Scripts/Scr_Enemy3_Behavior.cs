using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy3_Behavior : MonoBehaviour
{
    public List<GameObject> _bullets;
    private bool _movingRight;
    private bool _movingDown;
    public float _verticalSpeed;
    public float _horizontalSpeed;
    private float _shootDelay;
    public float _shootDelayOrigin;

    public float _maxSide;
    public float _maxHeight;


    // Start is called before the first frame update
    void Start()
    {
        _movingRight = true;
        _movingDown = true;
        _shootDelay = _shootDelayOrigin;
    }

    // Update is called once per frame
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
            for (int i = 0; i < _bullets.Count; i++)
            {
                Instantiate(_bullets[i], transform.position, Quaternion.identity);
            }

            _shootDelay = _shootDelayOrigin;
        }
    }
}
