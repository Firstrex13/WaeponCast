using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [SerializeField] private Collider _collider;
    [SerializeField] private AIEnemy _aIEnemy;

    private void Start()
    {
        Health.Died += MakeDisable;
    }

    private void OnDestroy()
    {

        Health.Died -= MakeDisable;
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
}
