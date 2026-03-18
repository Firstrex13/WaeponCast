using System;
using System.Collections;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

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
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SendWithDelay());
    }

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(3);

        yield return delay;
        Died?.Invoke(this);
    }


}
