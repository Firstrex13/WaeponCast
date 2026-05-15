using System;

[Serializable]
public class PlayerProgress
{
    public PlayerStats Stats;
    public CoinCounter Counter;

    public PlayerProgress(CoinCounter counter, PlayerStats playerStats)
    {
        Stats = playerStats;
        Counter = counter;
    }
}