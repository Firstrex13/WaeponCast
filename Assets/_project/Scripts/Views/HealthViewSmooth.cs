using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmooth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(Health health)
    {
        _health = health;
    }

    private void Start()
    {
        _text.text = _health.MaxValue.ToString();
        _health.Hit += UpdateValue;
    }

    private void OnDestroy()
    {
        _health.Hit -= UpdateValue;
    }

    public void UpdateValue()
    {
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
            _text.text = _health.CurrentHealth.ToString();
            yield return null;
        }
    }
}
