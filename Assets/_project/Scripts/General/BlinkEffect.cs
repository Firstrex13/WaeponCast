using System.Collections;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] private Health _health;

    private SkinnedMeshRenderer _renderer;
    private Coroutine _blink;

    private void Awake()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        _health.Hit += PlayBlink;
    }

    private void OnDisable()
    {
        _health.Hit -= PlayBlink;
    }

    private void PlayBlink()
    {
        if (gameObject.activeSelf)
        {
            if (_blink != null)
            {
                StopCoroutine(_blink);
            }

            _blink = StartCoroutine(PlayBlinkEffect());
        }
    }

    private IEnumerator PlayBlinkEffect()
    {
        WaitForSeconds interval = new WaitForSeconds(0.2f);

        _renderer.material.SetColor("_EmissionColor", Color.white);
        yield return interval;
        _renderer.material.SetColor("_EmissionColor", Color.black);
        yield return null;
    }
}
