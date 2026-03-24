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
        _slider.value = _mana.Max;
    }

    private void Update()
    {
        UpdateValue();
    }

    private void UpdateValue()
    {
        float currentValue = _mana.Current / _mana.Max;
        _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
        _text.text =Mathf.Ceil(_mana.Current).ToString();
    }
}
