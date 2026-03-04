using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSmooth : HealthViewBasic
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    public override void UpdateValue()
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

            float currentValue = Health.CurrentHealth / Health.MaxValue;

            _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
            _text.text = currentValue.ToString();
            yield return null;
        }
    }
}
