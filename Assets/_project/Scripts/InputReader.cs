using System;
using UnityEngine;
using static InputActions;

public class InputReader : MonoBehaviour
{
    private const string Desktop = "desktop";
    private const string Mobile = "mobile";
    private const string Tablet = "tablet";

    [SerializeField] private FloatingJoystick _joystick;

    public event Action<Vector3> Move;

    private InputActions _actions;

    private Vector3 _direction;

    private string _deviceType;

    public Vector3 Direction => _direction;


    private void Awake()
    {
        DeviceChecker deviceChecker = new DeviceChecker();
        _deviceType = deviceChecker.GetDeviceType();

        _actions = new InputActions();
    }
    private void OnEnable()
    {
        _actions.Enable();
    }

    private void Start()
    {
        if (_deviceType == Desktop)
        {
            _joystick.enabled = false;
        }
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Update()
    {
        GetDirection();
    }

    public Vector3 GetDirection()
    {
        if (_joystick.enabled)
        {
            _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        }
        else
        {
            _direction = _actions.Player.Move.ReadValue<Vector3>();
        }

        return _direction;
    }
}
