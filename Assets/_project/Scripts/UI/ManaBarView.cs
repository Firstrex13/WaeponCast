using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarView : MonoBehaviour
{
    [SerializeField] private Mana _mana;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _slider.value = _mana.MaxValue;
    }

    private void Update()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        float currentValue = _mana.CurrentValue / _mana.MaxValue;
        _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
        _text.text =Mathf.Ceil(_mana.CurrentValue).ToString();
    }
}
