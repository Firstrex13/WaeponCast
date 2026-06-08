using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmooth : MonoBehaviour
{
    [SerializeField] private BarComponent _health;
    [SerializeField] private Slider _slider;

    public BarComponent Health => _health;

    public virtual void OnEnable()
    {
        if (_slider != null)
        {
            _slider.value = _health.Max;
        }

        _health.Hit += UpdateValue;
    }

    public virtual void Start()
    {
        _slider.value = _health.Max;
    }

    private void OnDisable()
    {
        _health.Hit -= UpdateValue;
    }

    public virtual void UpdateValue()
    {
        if (gameObject.activeSelf)
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

    public void SetSlider(Slider slider)
    {
        _slider = slider;
    }
}
