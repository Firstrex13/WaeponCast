using System.IO;
using UnityEngine;
using Zenject;

public class GameSaver : MonoBehaviour
{
    private string _savePathStats;
    private string _savePathCounter;

    private CoinCounter _coinCounter;

    private void Awake()
    {
        _savePathStats = Path.Combine(Application.persistentDataPath, "player_save.json");
        _savePathCounter = Path.Combine(Application.persistentDataPath, "counter_save.json");
    }

    private void Start()
    {
        //DeleteSave();
        LoadGame();
        SaveGame();
    }

    [Inject]
    public void Construct(CoinCounter coinCounter)
    {
        _coinCounter = coinCounter;
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(PlayerData.Stats, true);
        string jsonCounter = JsonUtility.ToJson(CounterData.CoinCounter, true);
        File.WriteAllText(_savePathStats, json);
        File.WriteAllText(_savePathCounter, jsonCounter);
        Debug.Log($"{json} Game saved to {_savePathStats}");
        Debug.Log($"{jsonCounter} Game saved to {_savePathCounter}");
    }

    public bool LoadGame()
    {
        if (File.Exists(_savePathStats))
        {
            string json = File.ReadAllText(_savePathStats);

            PlayerData.Stats = JsonUtility.FromJson<PlayerStats>(json);

            if (File.Exists(_savePathCounter))
            {
                string jsonCounter = File.ReadAllText(_savePathCounter);
                _coinCounter.TotalCoinCount = JsonUtility.FromJson<CoinCounter>(jsonCounter).TotalCoinCount;         
            }          
        }

        return true;
    }

    public void DeleteSave()
    {
        if (File.Exists(_savePathStats))
        {
            File.Delete(_savePathStats);
            File.Delete(_savePathCounter);
            Debug.Log($"Save file has been deleted.");
        }
    }
}
