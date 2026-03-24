using TMPro;
using UnityEngine;

public class PlayerHealthView : HealthViewSmooth
{
    [SerializeField] private TextMeshProUGUI _text;

    public override void OnEnable()
    {
        base.OnEnable();
        _text.text = Health.Current.ToString();
    }

    public override void UpdateValue()
    {
        base.UpdateValue();
        _text.text = Health.Current.ToString();
    }
}
