using System;

[Serializable]
public class LevelManager
{
    public int CountOfOpenedLevels;

    public  LevelManager(int countOfOpenedLevels)
    {
        CountOfOpenedLevels = countOfOpenedLevels;
    }

    public void OpenNextLevel()
    {
        CountOfOpenedLevels++;
    }
}
