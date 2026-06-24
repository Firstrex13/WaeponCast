using System;

[Serializable]
public class PlayerProgress
{
    public PlayerStats Stats;
    public CoinCounter Counter;
    public LevelManager LevelManager;

    public PlayerProgress(CoinCounter counter, PlayerStats playerStats, LevelManager levelManager)
    {
        Stats = playerStats;
        Counter = counter;
        LevelManager = levelManager;
    }
}