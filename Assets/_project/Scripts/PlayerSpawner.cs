using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private FloatingJoystick _joystick;

    private PlayerPresenter _presenter;
    private Mover _mover;

    private void Awake()
    {
        _input.Initialize(_joystick);
        Player player = Instantiate(_player, Vector3.zero, Quaternion.identity);
        PlayerView view = player.GetComponent<PlayerView>();
        CharacterController controller = player.GetComponent<CharacterController>();
        Health health = player.GetComponent<Health>();
        HealthViewSmooth healthViewSmooth = player.GetComponent<HealthViewSmooth>();
        healthViewSmooth.Initialize(health);
        _mover = new Mover(controller);

        _presenter = new PlayerPresenter(view, health, _mover, _input);
        player.Initialize(_presenter);
    }
}
