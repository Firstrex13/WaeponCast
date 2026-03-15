using UnityEngine;

public class Knife : MonoBehaviour
{
    public void Initialize(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(40);
            Destroy(gameObject);
        }
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
