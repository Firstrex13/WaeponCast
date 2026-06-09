using UnityEngine;
using Zenject;
using YG;

public class GameSaver : MonoBehaviour
{
    public PlayerProgress Progress { get; private set; }

    private CoinCounter _coinCounter;

    [Inject]
    public void Construct(IProgressService progress)
    {
        _coinCounter = progress.GetProgress().Counter;
        Progress = progress.GetProgress();
    }

    public PlayerProgress LoadGame()
    {
        if (YG2.saves.Json != null)
        {
            Progress = JsonUtility.FromJson<PlayerProgress>(YG2.saves.Json);
            return Progress;
        }
        else
        {
            PlayerProgress progress = new PlayerProgress(new CoinCounter(), new PlayerStats(100, 100, 0, 0, 10, 5, 2, 0.1f));
            return progress;
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(Progress);
        YG2.saves.Json = json;
        YG2.SaveProgress();
    }

    public void ResetProgress()
    {
        if (YG2.saves.Json != null)
        {
            YG2.SetDefaultSaves();
            Progress = new PlayerProgress(new CoinCounter(), new PlayerStats(100, 100, 0, 0, 10, 5, 2, 0.1f));
            _coinCounter.SetTotalCount(0);
            string json = JsonUtility.ToJson(Progress);
            YG2.saves.Json = json;
            YG2.SaveProgress();

        }
    }
}
