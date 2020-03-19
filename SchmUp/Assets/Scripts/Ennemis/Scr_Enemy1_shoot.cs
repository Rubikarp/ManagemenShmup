using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Enemy1_shoot : MonoBehaviour
{
    private Vector2 _movePos1;
    private Vector2 _movePos2;
    private Vector2 _directionContinue;
    public float _move1Time;
    public float _move2Time;
    private bool _move1Set;
    private bool _move2Set;

    public GameObject _player;
    public Vector2 _playerPos;
    public float _moveSpeed;
    private bool _targetAttained;
    public int _shootDamage;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.transform.position;
        _targetAttained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetAttained == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPos, _moveSpeed * Time.deltaTime);
        }
        else if (_targetAttained == true)
        {
            transform.position = new Vector2 (transform.position.x + (_directionContinue.x * Time.deltaTime * _moveSpeed), transform.position.y + (_directionContinue.y * Time.deltaTime * _moveSpeed));
        }


        if (_move1Time > 0)
        {
            _move1Time -= Time.deltaTime;
        }
        else if (_move1Time <= 0 && _move1Set == false)
        {
            _movePos1 = transform.position;
            _move1Set = true;
        }

        if (_move2Time > 0)
        {
            _move2Time -= Time.deltaTime;
        }
        else if (_move2Time <= 0 && _move2Set == false)
        {
            _movePos2 = transform.position;
            _move2Set = true;
        }


        if (_move1Set == true && _move2Set == true)
        {
            _directionContinue = _movePos2 - _movePos1;
        }

        if (transform.position.x == _playerPos.x && transform.position.y == _playerPos.y)
        {
            _targetAttained = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scr_LifeSystem_Player lifesyst = collision.gameObject.GetComponent<Scr_LifeSystem_Player>();

            if (!lifesyst._haveTakeDamage)
            {
                lifesyst.TakingDamange(_shootDamage);
            }

            Destroy(gameObject);
        }
    }
}
