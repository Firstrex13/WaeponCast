using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
}
