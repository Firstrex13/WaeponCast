using TMPro;
using UnityEngine;
using Zenject;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    private IProgressService _progressService;
    private CoinCounter _coinCounter;

    [Inject]
    public void Construct(IProgressService progress)
    {
        _progressService = progress;
        _coinCounter = _progressService.GetProgress().Counter;
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
        _coinText.text = _coinCounter.CoinCountOnLevel.ToString();
    }
}
