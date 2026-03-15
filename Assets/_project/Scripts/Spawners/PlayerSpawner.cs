using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private FloatingJoystick _floatingJoystick;

    private Player _player;

    private void Awake()
    {
        FollowPoint followPoint = _player.GetComponentInChildren<FollowPoint>();
        _camera.Initialize(_player.transform);
        PlayerController playerController = _player.GetComponent<PlayerController>();
        playerController.Initialize(_floatingJoystick);
    }

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }
}
