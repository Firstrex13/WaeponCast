using TMPro;
using UnityEngine;

public class PlayerHealthView : HealthViewSmooth
{
    [SerializeField] private TextMeshProUGUI _text;

    public override void OnEnable()
    {
        Initialize();
        base.OnEnable();
        _text.text = Health.Current.ToString();
    }

    public override void Start()
    {
        base.Start();
        _text.text = Health.Current.ToString();
    }

    public void Initialize()
    {
        _text.text = Health.Current.ToString();
    }

    public override void UpdateValue()
    {
        base.UpdateValue();
        _text.text = Health.Current.ToString();
    }
}
