using TMPro;
using UnityEngine;

public class WavesCounterView : MonoBehaviour
{
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private TextMeshProUGUI _wavesCountText;

    private void OnEnable()
    {
        _enemiesSpawner.WaveChanged += UpdateCoinCount;
    }

    private void OnDisable()
    {
        _enemiesSpawner.WaveChanged -= UpdateCoinCount;
    }

    private void UpdateCoinCount(int number)
    {
      _wavesCountText.text = number.ToString();
    }
}
