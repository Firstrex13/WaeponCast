using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private int _collidedDamage = 1;
    public event Action<int> CollidedWithEnemy;
    


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.TryGetComponent<Enemy>(out _))
        {
            CollidedWithEnemy?.Invoke(_collidedDamage);
        }
    }
}
