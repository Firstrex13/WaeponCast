using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyHealth Health;
    [SerializeField] private Collider _collider;
    [SerializeField] private AIEnemy _aIEnemy;

    private Coroutine _dieMessage;

    private void Start()
    {
        Health.Died += DieWithDelay; ;
    }

    private void OnDestroy()
    {
        Health.Died -= DieWithDelay;
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

    private void DieWithDelay()
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
        gameObject.SetActive(false);
    }
}
