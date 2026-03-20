using UnityEngine;

[CreateAssetMenu(fileName = "HealthConfig", menuName = "Config/HealthConfig")]
public class HealthConfig : ScriptableObject
{
    [field: SerializeField] public int Health {  get; private set; }
}
