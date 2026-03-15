using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    private Transform _followPoint;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        _camera.Follow = _followPoint;
    }

    [Inject]
    public void Initialize(Player point)
    {
        _followPoint = point.transform;
    }
}
