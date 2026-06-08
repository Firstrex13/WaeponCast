using UnityEngine;

public class BarLook : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.rotation = _camera.transform.rotation;
    }
}
