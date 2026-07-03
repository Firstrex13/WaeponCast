using System;

public enum WeaponsList
{
    LIGHTNING,
    FIREBALL
}

[Serializable]
public class Weapons
{
    public const string LIGHTNING = "Lightning";
    public const string FIREBALL = "Fireball";

    public WeaponsList CurrentWeapon; 

    public Weapons(WeaponsList weaponsList)
    {
        CurrentWeapon = weaponsList;
    }
}
