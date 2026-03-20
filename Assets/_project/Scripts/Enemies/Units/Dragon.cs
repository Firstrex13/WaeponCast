using System;
using System.Collections;
using UnityEngine;

public class Dragon : Enemy
{
    private Coroutine _coroutine;

    public event Action<Dragon> Died;

    private void OnEnable()
    {
        Health.Died += SendDieMessage;
    }

    private void OnDisable()
    {
        Health.Died -= SendDieMessage;
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
        WaitForSeconds delay = new WaitForSeconds(1.5f);

        yield return delay;
        Died?.Invoke(this);
    }


}
