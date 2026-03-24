public class PlayerStats 
{
    public int Health;
    public int Mana;

    public PlayerStats(int health, int mana)
    {
        Health = health;
        Mana = mana;
    }

    public void UpgradeHealth()
    {
        Health += 10;
    }

    public void UpgradeMana()
    {
        Mana += 5;
    }
}

public static class PlayerData
{
    public static PlayerStats Stats = new PlayerStats(100, 50);
}
