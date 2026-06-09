using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    public Vector3 Velocity { get; private set; }

    private void Update()
    {
        GetDirection();
    }

    public void GetDirection()
    {
        Velocity = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
    }
}
