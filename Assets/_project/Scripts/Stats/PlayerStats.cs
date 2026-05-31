using System;

[Serializable]
public class PlayerStats 
{
    public int Health;
    public int Mana;
    public int Force;
    public float AttackRate;

    public int UpgradeHealthCount;
    public int UpgradeManaCount;
    public int UpgradeForceCount;
    public float UpgradeAttackRateCount;

    public PlayerStats(int health, int mana, int force, float attackRate, int upgadeHealthCost, int upgradeManaCount, int upgradeForceCount, float upgradeAttackRateCount)
    {
        Health = health;
        Mana = mana;
        Force = force;
        AttackRate = attackRate;
        UpgradeHealthCount = upgadeHealthCost;
        UpgradeManaCount = upgradeManaCount;
        UpgradeForceCount = upgradeForceCount;
        UpgradeAttackRateCount = upgradeAttackRateCount;
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
    public void UpgradeAttackRate()
    {
        if(AttackRate >= 1f)
        {
            return;
        }

        AttackRate +=UpgradeAttackRateCount;
    }
}