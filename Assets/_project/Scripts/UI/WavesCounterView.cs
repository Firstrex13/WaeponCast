using TMPro;
using UnityEngine;

public class WavesCounterView : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private TextMeshProUGUI _wavesCountText;
    [SerializeField] private TextMeshProUGUI _totalWavesCountText;

    private void OnEnable()
    {
        _enemiesSpawner.WaveChanged += UpdateCoinCount;
        _totalWavesCountText.text = _enemiesSpawner.Waves.Count.ToString();
    }

    private void OnDisable()
    {
        _enemiesSpawner.WaveChanged -= UpdateCoinCount;
    }

    private void UpdateCoinCount(int number)
    {
        _wavesCountText.text = number.ToString();
        _totalWavesCountText.text = _enemiesSpawner.Waves.Count.ToString();
    }
}
