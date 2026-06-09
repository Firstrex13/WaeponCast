using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _playerAnimations;

    private InputReader _inputReader;
    private Rigidbody _rigidbody;

    private bool _moving;
    private bool _canMove;
    private float _timer;
    private float _stopPeriod = 1f;

    public bool Moving => _moving;
    public bool CanMove => _canMove;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _canMove = true;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _canMove = true;
        }
    }

    [Inject]
    public void Construct(InputReader input)
    {
        _inputReader = input;
    }

    private void Rotate()
    {
        if (!_canMove)
        {
            return;
        }

        if (_inputReader.Velocity != Vector3.zero)
        {
            _moving = true;
            Quaternion lookRotation = Quaternion.LookRotation(_inputReader.Velocity);
            LookAtNeedDirection(lookRotation);
        }
        else
        {
            _moving = false;
            if (_unitChecker.NearestEnemy)
            {
                Quaternion lookRotation = Quaternion.LookRotation(_unitChecker.NearestEnemy.transform.position - transform.position);
                LookAtNeedDirection(lookRotation);
            }
        }
    }

    private void LookAtNeedDirection(Quaternion lookRotation)
    {
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    private void Move()
    {
        if (_canMove)
        {
            _playerAnimations.PlayMove(_inputReader.Velocity.magnitude);
            _rigidbody.velocity = _inputReader.Velocity * _moveSpeed;
        }
    }

    public void MakeDisable()
    {
        enabled = false;
    }

    public void StopPlayer()
    {
        _canMove = false;
        _timer = _stopPeriod;   
    }
}
