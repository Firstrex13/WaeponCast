using System;

[Serializable]
public class PlayerStats 
{
    public int Health;
    public int Mana;
    public int Force;

    public int UpgradeHealthCount;
    public int UpgradeManaCount;
    public int UpgradeForceCount;

    public PlayerStats(int health, int mana, int force, int upgadeHealthCost, int upgradeManaCount, int upgradeForceCount)
    {
        Health = health;
        Mana = mana;
        Force = force;
        UpgradeHealthCount = upgadeHealthCost;
        UpgradeManaCount = upgradeManaCount;
        UpgradeForceCount = upgradeForceCount;
    }

    public void UpgradeHealth()
    {
        Health += UpgradeHealthCount;
    }

    public void UpgradeMana()
    {
        Mana += UpgradeManaCount;
    }
    public void UpgradeForce()
    {
        Force += UpgradeForceCount;
    }

}