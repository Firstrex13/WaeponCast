using UnityEngine;
using UnityEngine.UI;

public class ManaBarView : MonoBehaviour
{
    [SerializeField] private Mana _mana;
    [SerializeField] private Slider _slider;

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
        float currentValue = _mana.CurrentMana / _mana.MaxValue;
        _slider.value = Mathf.MoveTowards(_slider.value, currentValue, Time.deltaTime);
    }
}
