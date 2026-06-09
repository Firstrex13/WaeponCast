using System;

[Serializable]
public class CoinCounter
{
    public int TotalCoinCount;
    private int _coinCountOnLevel;

    public int CoinCountOnLevel => _coinCountOnLevel;
    public int TotalCoins => TotalCoinCount;

    public event Action CoinCountUpdated;

    public void AddCoin()
    {
        _coinCountOnLevel++;
        CoinCountUpdated?.Invoke();
    }

    public void AddCoinsToTotalCount()
    {
        TotalCoinCount += _coinCountOnLevel;
        _coinCountOnLevel = 0;
    }

    public void SetTotalCount(int count)
    {
        TotalCoinCount = count;
    }

    public void DecreaseCoin(int cost)
    {
        TotalCoinCount -= cost;
        CoinCountUpdated?.Invoke();
    }
}