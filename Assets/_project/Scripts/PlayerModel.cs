using UnityEngine;

public class PlayerModel
{
    private Mover _mover;
    private Health _health;
 
    public PlayerModel(Mover mover, Health health)
    {
        _mover = mover;
        _health = health;
    }

    public void Move(Vector3 direction)
    {
        _mover.Move(direction);
    }

    public void Rotate(Vector3 direction)
    {
        _mover.Rotate(direction);
    }

    public void OnDetected(int damage)
    {
        _health.TakeDamage(damage);
    }
}
