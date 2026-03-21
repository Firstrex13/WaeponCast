using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _playerAnimations;

    private FloatingJoystick _joystick;
    private Rigidbody _rigidbody;

    private bool _moving;

    public Vector3 Velocity { get; private set; }
    public bool Moving => _moving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetVelocity();
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
        if (Velocity != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Velocity);
            float step = _rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
        else
        {
            if (_unitChecker.NearestEnemy)
            {
                Quaternion lookRotation = Quaternion.LookRotation(_unitChecker.NearestEnemy.transform.position - transform.position);
                float step = _rotationSpeed * Time.deltaTime;

                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
            }
        }
    }

    private void Move()
    {
        _rigidbody.AddForce(Velocity * _moveSpeed, ForceMode.VelocityChange);
        _playerAnimations.PlayMove(Velocity.magnitude);
    }

    private void GetVelocity()
    {
        Velocity = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (Velocity != Vector3.zero)
        {
            _moving = true;
        }
        else
        {
            _moving = false;
        }
    }

    public void MakeDisable()
    {
        enabled = false;
    }
}
