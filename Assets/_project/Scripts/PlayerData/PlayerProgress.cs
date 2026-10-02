using System;

[Serializable]
public class PlayerProgress
{
    public PlayerStats Stats;
    public CoinCounter Counter;
    public LevelManager LevelManager;
    public Weapons Weapons;
    public Leaderboard Leaderboard;
    public bool FirstPlay;


    public PlayerProgress(CoinCounter counter, PlayerStats playerStats, LevelManager levelManager, Weapons weapons, Leaderboard leaderboard, bool firstPlay)
    {
        Stats = playerStats;
        Counter = counter;
        LevelManager = levelManager;
        Weapons = weapons;
        Leaderboard = leaderboard;
        FirstPlay = firstPlay;

    }
}