using Unity.VisualScripting;
using UnityEngine;

public class TrapProjectile : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(gameObject);
    }
}
