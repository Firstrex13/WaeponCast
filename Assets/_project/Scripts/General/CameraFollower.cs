using Cinemachine;
using UnityEngine;

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

    public void Initialize(Transform point)
    {
        _followPoint = point;
    }
}
