using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy3_Behavior : MonoBehaviour
{
    public GameObject _bullet;
    private bool _canShoot;
    private bool _movingRight;
    public float _verticalSpeed;
    public float _horizontalSpeed;
    private float _timeForTurn;
    public float _timeForTurnOrigin;
    private bool _firstTurnMade;


    // Start is called before the first frame update
    void Start()
    {
        _movingRight = true;
        _firstTurnMade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_movingRight == true)
        {
            transform.position = new Vector2(transform.position.x + (_horizontalSpeed * Time.deltaTime), transform.position.y - (_verticalSpeed * Time.deltaTime));
        }
        else if (_movingRight == false)
        {
            transform.position = new Vector2(transform.position.x - (_horizontalSpeed * Time.deltaTime), transform.position.y - (_verticalSpeed * Time.deltaTime));
        }

        if (_timeForTurn > 0)
        {
            _timeForTurn -= Time.deltaTime;
        }
        else if (_timeForTurn <= 0)
        {
            if (_movingRight == true)
            {
                _movingRight = false;
            }
            else if (_movingRight == false)
            {
                _movingRight = true;
            }

            _timeForTurn = _timeForTurnOrigin;

            if (_firstTurnMade == false)
            {
                _firstTurnMade = true;
                _timeForTurnOrigin = _timeForTurnOrigin * 2;
            }
        }
    }
}
