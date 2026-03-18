using System;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action<Dragon> Died;

    private void OnEnable()
    {
        _health.Died += SendDieMessage;
    }

    private void OnDisable()
    {
        _health.Died -= SendDieMessage;
    }

    private void SendDieMessage()
    {
        Died?.Invoke(this);
    }


}
