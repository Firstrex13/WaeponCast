using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private FloatingJoystick _joystick;

    private Vector3 _direction;

    public event Action<Vector3> IsMoving;
    public event Action Stopped;

    private void Update()
    {
        MoveStick();
    }

    public void Initialize(FloatingJoystick floatingJoystick)
    {
        _joystick = floatingJoystick;
    }

    public void MoveStick()
    {
        _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (_direction != Vector3.zero)
        {
            IsMoving?.Invoke(_direction);
        }
        else
        {
            Stopped?.Invoke();
        }
    }

    public void Disable()
    {
        this.enabled = false;
    }
}
