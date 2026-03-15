using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Collider _collider;
    [SerializeField] private AIEnemy _aIEnemy;

    private void Start()
    {

        _health.Died += MakeDisable;
    }

    private void OnDestroy()
    {

        _health.Died -= MakeDisable;
    }

    private void MakeDisable()
    {
        _collider.enabled = false;
        _aIEnemy.MakeDisable();
        enabled = false;
    }
}
