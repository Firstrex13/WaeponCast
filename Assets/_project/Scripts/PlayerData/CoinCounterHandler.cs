using UnityEngine;
using Zenject;

public class CoinCounterHandler : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;

    private CoinCounter _coinCounter;

    [Inject]
    public void Construct(IProgressService progress)
    {
        _coinCounter = progress.GetProgress().Counter;
    }

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
        _coinCounter.AddCoin();
       
    }
}
