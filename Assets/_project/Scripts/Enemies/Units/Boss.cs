using System.Collections;
using UnityEngine;

public class Boss : Enemy
{
    private void Start()
    {
        Health.EnemyDied += DieWithDelay; ;
    }

    private void OnDestroy()
    {
        Health.EnemyDied -= DieWithDelay;
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

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(1.5f);

        yield return delay;

        int randomNumber = UnityEngine.Random.Range(0, 100);

        Destroy(gameObject);
        SendDieMessage(this);   
    }

    public override void MakeDisable()
    {
        base.MakeDisable();
        enabled = false;
    }
}
