using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmooth : MonoBehaviour
{
    [SerializeField] private Bar _health;
    [SerializeField] private Slider _slider;

    public Bar Health => _health;

    public virtual void OnEnable()
    {
        _slider.value = _health.Max;
        _health.Hit += UpdateValue;
    }

    private void Start()
    {
        _slider.value = _health.Max;
    }

    private void OnDisable()
    {
        _health.Hit -= UpdateValue;
    }

    public virtual void UpdateValue()
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

            float currentValue = _health.Current / _health.Max;

            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
            yield return null;
        }
    }
}
