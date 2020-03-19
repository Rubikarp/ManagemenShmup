using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Scr_Character_Moving : MonoBehaviour
{
    #region Loulou Code init
    /*
     private bool isOnCameraRightSide;
     private bool isOnCameraLeftSide;
     private float sideSpeed = 5f;
     private float leftSideCamera = -8f;
     private float rightSideCamera = 8f;
    */
    #endregion

    [Header("Component")]
    private Scr_InputManager _input = null;
    private Transform _transform = null;

    [Header("Statistique")]
    public float _speed = 10f;

    [Header("Option")]
    public bool _mouseControl = false;
    [Space(10)]
    public bool _teleportHorizontal = true;
    public bool _teleportVertical = false;

    [Header("Edges")]
    [SerializeField] private Transform _leftDownEdge = null;
    [SerializeField] private Transform _rightUpEdge = null;

    private void Start()
    {
        #region Loulou Code Start
        //isOnCameraRightSide = false;
        //isOnCameraLeftSide = false;
        #endregion

        _input = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scr_InputManager>();

        _transform = this.transform;
    }

    void Update()
    {
        #region Loulou Code
        /*
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
        */
        #endregion

        #region Moving SpaceShip
        if (_mouseControl)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 direction = new Vector2( mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            _transform.position += direction;
        }
        else
        {
            if (_input._RightInput && _transform.position.x <= _rightUpEdge.position.x)
            {
                Move(Vector2.right, _speed);
            }
            if (_input._LeftInput && _transform.position.x >= _leftDownEdge.position.x)
            {
                Move(Vector2.left, _speed);
            }
            if (_input._DownInput && _transform.position.y >= _leftDownEdge.position.y)
            {
                Move(Vector2.down, _speed);
            }
            if (_input._UpInput && _transform.position.y <= _rightUpEdge.position.y)
            {
                Move(Vector2.up, _speed);
            }
        }
        
        #endregion

        #region Teleport when touching Edge
        if (_teleportHorizontal)
        {   //Left
            if (_transform.position.x < _leftDownEdge.position.x)
            {
                _transform.position = new Vector2(_rightUpEdge.position.x, _transform.position.y);
            }

            //Right
            if (_transform.position.x > _rightUpEdge.position.x)
            {
                _transform.position = new Vector2(_leftDownEdge.position.x, _transform.position.y);
            }

        }

        if (_teleportVertical)
        {   //Down
            if (_transform.position.y < _leftDownEdge.position.y)
            {
                _transform.position = new Vector2(_transform.position.x, _rightUpEdge.position.y);
            }

            //Up
            if (_transform.position.y > _rightUpEdge.position.y)
            {
                _transform.position = new Vector2(_transform.position.x, _leftDownEdge.position.y);
            }
        }
        #endregion

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(_leftDownEdge.position, Vector3.right * 16, Color.red);
        Debug.DrawRay(_leftDownEdge.position, Vector3.up * 9, Color.red);
        Debug.DrawRay(_rightUpEdge.position, Vector3.left * 16, Color.red);
        Debug.DrawRay(_rightUpEdge.position, Vector3.down * 9, Color.red);
    }

    private void Move(Vector3 Direction, float Speed)
    {
        _transform.position += Direction * Speed * Time.deltaTime;
    }

}
