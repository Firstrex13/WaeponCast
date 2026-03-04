using UnityEngine;

public class PlayerPresenter
{
    private PlayerView _playerView;
    private PlayerModel _model;
    private PlayerInput _playerInput;
    private CollisionDetector _collisionDetector;

    public PlayerPresenter(PlayerView view, PlayerModel model, PlayerInput input, CollisionDetector detector)
    {
        _playerView = view;
        _model = model;
        _playerInput = input;
        _collisionDetector = detector;
    }

    public void Enable()
    {
        _collisionDetector.CollidedWithEnemy += OnDetected;
        _playerInput.IsMoving += Move;
        _playerInput.IsMoving += Rotate;
        _playerInput.IsMoving += SetRunAnim;
        _playerInput.Stopped += SetIdleAnim;
    }

    public void Disable()
    {
        _collisionDetector.CollidedWithEnemy -= OnDetected;
        _playerInput.IsMoving -= Move;
        _playerInput.IsMoving -= Rotate;
        _playerInput.IsMoving -= SetRunAnim;
        _playerInput.Stopped -= SetIdleAnim;
    }

    private void Move(Vector3 direction)
    {
        _model.Move(direction);
    }

    private void Rotate(Vector3 direction)
    {
        _model.Rotate(direction);
    }

    private void SetRunAnim(Vector3 direction)
    {
        _playerView.PlayRun();
    }

    private void SetIdleAnim()
    {
        _playerView.PlayIdle();
    }

    private void OnDetected(int damage)
    {
        _model.OnDetected(damage);
    }
}
