using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthView : HealthViewSmooth
{
    [SerializeField] private TextMeshProUGUI _text;

    public override void Start()
    {
        base.Start();
        _text.text = Health.Current.ToString();
    }

    public override void UpdateValue()
    {
        base.UpdateValue();
        _text.text = Health.Current.ToString();
    }

    public void Initialize(Slider slider, TextMeshProUGUI text)
    {
        SetSlider(slider);
        _text = text;
        _text.text = Health.Current.ToString();
    }
}
