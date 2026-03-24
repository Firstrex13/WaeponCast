using System.IO;
using UnityEngine;

public class Saver : MonoBehaviour
{
    private string _savePath;

    private void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "player_save.json");
    }

    private void Start()
    {
       //DeleteSave();
      LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(PlayerData.Stats, true);
        File.WriteAllText(_savePath, json);
        Debug.Log($"{json} Game saved to {_savePath}");
    }

    public bool LoadGame()
    {
        if(File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            PlayerData.Stats = JsonUtility.FromJson<PlayerStats>(json);
            return true;
        }
        else
        {
            Debug.Log($"Save File hasn't found.");
            return false;
        }
    }

    public void DeleteSave()
    {
        if(File.Exists(_savePath))
        {
            File.Delete(_savePath);
            Debug.Log($"Save file has been deleted.");
        }
    }
}
