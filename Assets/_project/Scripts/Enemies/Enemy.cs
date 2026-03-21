using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] private Collider _collider;
    [SerializeField] private AIEnemy _aIEnemy;

    public event Action<Enemy> Died;

    private Coroutine _dieMessage;

    private void Start()
    {
        Health.Died += SendDieMessage; ;
    }

    private void OnDestroy()
    {

        Health.Died -= SendDieMessage;
    }
    public void MakeEnable()
    {
        _collider.enabled = true;
        _aIEnemy.MakeEnable();
        enabled = true;
    }

    private void MakeDisable()
    {
        _collider.enabled = false;
        _aIEnemy.MakeDisable();
        enabled = false;
    }

    private void SendDieMessage()
    {
        MakeDisable();

        if (_dieMessage != null)
        {
            StopCoroutine(_dieMessage);
        }

        _dieMessage = StartCoroutine(SendWithDelay());
    }

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(1.5f);

        yield return delay;
        Died?.Invoke(this);
    }
}
