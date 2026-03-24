using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private void OnEnable()
    {
        _health.Died += Destroy; 
    }

    private void OnDisable()
    {
        _health.Died -= Destroy;
    }

    private void Destroy()
    {
        Destroy(gameObject, 3f);
    }
}
