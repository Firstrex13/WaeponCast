using TMPro;
using UnityEngine;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private int _coinCount;

    private void OnEnable()
    {
        _coinSpawner.CoinCreated += UpdateCoinCount;
    }

    private void OnDisable()
    {
        _coinSpawner.CoinCreated -= UpdateCoinCount;
    }

    private void UpdateCoinCount()
    {
        _coinCount++;
        _coinText.text = _coinCount.ToString();
    }
}
