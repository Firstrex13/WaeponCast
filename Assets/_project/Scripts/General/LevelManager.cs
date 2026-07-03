using System;

[Serializable]
public class LevelManager
{
    public int CountOfOpenedLevels;
    public string CurrentLevelName;

    public  LevelManager(int countOfOpenedLevels)
    {
        CountOfOpenedLevels = countOfOpenedLevels;
    }

    public void OpenNextLevel()
    {
        CountOfOpenedLevels++;
    }

    public void SetCurrentLevel(string level)
    {
        CurrentLevelName = level;
    }
}
