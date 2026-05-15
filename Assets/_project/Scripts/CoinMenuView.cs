using TMPro;
using UnityEngine;
using Zenject;

public class CoinMenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    private CoinCounter _coinCounter;

    [Inject]
    public void Construct(IProgressService progress)
    {
        _coinCounter = progress.GetProgress().Counter;
    }

    private void Start()
    {
        UpdateCoinCount();
    }

    private void OnEnable()
    {
        _coinCounter.CoinCountUpdated += UpdateCoinCount;
    }

    private void OnDisable()
    {
        _coinCounter.CoinCountUpdated -= UpdateCoinCount;
    }

    private void UpdateCoinCount()
    {
        _coinText.text = _coinCounter.TotalCoinCount.ToString();
    }
}
