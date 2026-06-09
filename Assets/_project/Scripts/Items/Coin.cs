using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _coinEffect;

    private float _rotationSpeed = 100;
    private Coroutine SendMessageCoroutine;

    private void Start()
    {
        if(SendMessageCoroutine != null)
        {
            StopCoroutine(SendMessageCoroutine);
        }

        SendMessageCoroutine = StartCoroutine(SendWithDelay());
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
    }

    private IEnumerator SendWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(3);
        yield return delay;
        Instantiate(_coinEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
