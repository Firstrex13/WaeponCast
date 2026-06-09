using System;
using System.Collections;
using UnityEngine;

public class EnemyUnit : Enemy
{
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private int _coinDropChance = 20;

    public event Action<EnemyUnit> CoinDropped;

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
        AIEnemy.MakeEnable();
        enabled = true;
    }

    public void DieWithDelay()
    {
        MakeDisable();

        if (DieMessage != null)
        {
            StopCoroutine(DieMessage);
        }

        DieMessage = StartCoroutine(SendWithDelay());
    }

    public override void MakeDisable()
    {
        _collider.enabled = false;
        base.MakeDisable();
        enabled = false;
    }

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(1.5f);

        yield return delay;
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
        int randomNumber = UnityEngine.Random.Range(0, 100);
        gameObject.SetActive(false);
        SendDieMessage(this);

        if (randomNumber < _coinDropChance)
        {
            CoinDropped?.Invoke(this);
        }
    }
}
