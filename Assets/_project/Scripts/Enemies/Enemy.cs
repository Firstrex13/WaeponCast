using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyHealth Health;
    [SerializeField] protected AIEnemy AIEnemy;

    protected Coroutine DieMessage;

    public event Action<Enemy> Died;

    public EnemyHealth EnemyHealth => Health;

    protected void SendDieMessage(Enemy enemy)
    {
        Died?.Invoke(enemy);
    }

    public virtual void MakeDisable()
    {
        AIEnemy.MakeDisable();
    }
}
