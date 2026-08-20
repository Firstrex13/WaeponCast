using YG;


public class Leaderboard 
{
   public void SetRecord(int coinCount)
    {
        YG2.SetLeaderboard("LeaderboardDesk", coinCount);
    }
}
