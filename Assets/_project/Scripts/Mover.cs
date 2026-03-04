using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover
{
    private CharacterController _characterController;

    private float _moveSpeed = 5f;

    public Mover(CharacterController controller)
    {
        _characterController = controller;
    }

    public void Rotate(Vector3 direction)
    {
        _characterController.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * _moveSpeed * Time.deltaTime);
    }
}
