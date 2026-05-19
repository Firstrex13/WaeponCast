using System;

[Serializable]
public class PlayerStats 
{
    public int Health;
    public int Mana;
    public int Force;

    public int UpgradeHealthCount;
    public int UpgradeManaCount;

    public PlayerStats(int health, int mana, int force, int upgadeHealthCost, int upgradeManaCount)
    {
        Health = health;
        Mana = mana;
        Force = force;
        UpgradeHealthCount = upgadeHealthCost;
        UpgradeManaCount = upgradeManaCount;
    }

    public void UpgradeHealth()
    {
        Health += UpgradeHealthCount;
    }

    public void UpgradeMana()
    {
        Mana += UpgradeManaCount;
    }
}