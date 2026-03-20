using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmooth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = _health.MaxValue;
        _health.Hit += UpdateValue;
    }

    private void Start()
    {
        _slider.value = _health.MaxValue;
    }

    private void OnDisable()
    {
        _health.Hit -= UpdateValue;
    }

    public void UpdateValue()
    {
        if(gameObject.activeSelf) 
        StartCoroutine(nameof(ChangeValue));
    }

    private IEnumerator ChangeValue()
    {
        float duration = 1f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float currentValue = _health.CurrentHealth / _health.MaxValue;

            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
            yield return null;
        }
    }
}
