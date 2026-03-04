using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private HealthViewBasic _healthBasic;

    private PlayerPresenter _presenter;
    private PlayerModel _model;
    private Mover _mover;

    private void Start()
    {
        _input.Initialize(_joystick);
        Player player = Instantiate(_player, Vector3.zero, Quaternion.identity);
        PlayerView view = player.GetComponent<PlayerView>();
        CharacterController controller = player.GetComponent<CharacterController>();
        Health health = new Health();
        health.Initialize();
        _healthBasic.Initialize(health);
        _mover = new Mover(controller);
        _model = new PlayerModel(_mover, health);

        _presenter = new PlayerPresenter(view, _model, _input, _collisionDetector);
        player.Initialize(_presenter);
    }
}
