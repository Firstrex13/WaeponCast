using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " StartStats", menuName = "Stats/StartStats")]

public class StartPlayerStats : ScriptableObject
{
    public int Health;
    public int Mana;
    public int Force;
    public float AttackRate;
}
