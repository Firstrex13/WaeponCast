using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private Health _health;

    private FloatingJoystick _joystick;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private bool _moving;

    public bool Moving => _moving;

    public event Action IsMoving;
    public event Action IsStopped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _health.Died += MakeDisable;
    }

    private void OnDestroy()
    {
        _health.Died -= MakeDisable;
    }

    private void Update()
    {
        GetDirection();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    [Inject]
    public void Initialize(FloatingJoystick floatingJoystick)
    {
        _joystick = floatingJoystick;
    }

    private void Rotate()
    {
        if (_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_direction);
        }
        else
        {
            if (_unitChecker.NearestEnemy)
            {
                transform.rotation = Quaternion.LookRotation(_unitChecker.NearestEnemy.transform.position - transform.position);
            }
        }
    }

    private void Move()
    {
        _rigidbody.AddForce(_direction * _moveSpeed, ForceMode.VelocityChange);
    }

    private void GetDirection()
    {
        _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (_direction != Vector3.zero)
        {
            IsMoving?.Invoke();
            _moving = true;
        }
        else
        {
            IsStopped?.Invoke();
            _moving = false;
        }
    }

    private void MakeDisable()
    {
        enabled = false;
    }
}
