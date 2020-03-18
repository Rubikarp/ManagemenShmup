using UnityEngine;

public class Scr_InputManager : MonoBehaviour
{
    [SerializeField] private bool _shootInput;

    [SerializeField] private bool _leftInput;
    [SerializeField] private bool _rightInput;
    [SerializeField] private bool _downInput;
    [SerializeField] private bool _upInput;

    public bool _ShootInput
    {
        get
        {
            return _shootInput;
        }
    }

    public bool _LeftInput
    {
        get
        {
            return _leftInput;
        }
    }
    public bool _RightInput
    {
        get
        {
            return _rightInput;
        }
    }
    public bool _DownInput
    {
        get
        {
            return _downInput;
        }
    }
    public bool _UpInput
    {
        get
        {
            return _upInput;
        }
    }

    private void Update()
    {
        //Setting Left Input
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            _leftInput = true;
        }
        else
        {
            _leftInput = false;
        }

        //Setting Right Input
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rightInput = true;
        }
        else
        {
            _rightInput = false;
        }

        //Setting Down Input
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _downInput = true;
        }
        else
        {
            _downInput = false;
        }

        //Setting Up Input
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
        {
            _upInput = true;
        }
        else
        {
            _upInput = false;
        }

        //Setting Shoot Input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.E) || Input.GetMouseButton(0))
        {
            _shootInput = true;
        }
        else
        {
            _shootInput = false;
        }
    }
}