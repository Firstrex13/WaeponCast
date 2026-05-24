using UnityEngine;

public class AbilityBossUser : AbillityUser
{
    public void ThrowWeapon()
    {
        Weapon.Throw(SpawnPosition);
    }
}
