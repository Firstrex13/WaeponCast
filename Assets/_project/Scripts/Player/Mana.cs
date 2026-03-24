using UnityEngine;

public class Mana : Bar
{
    [SerializeField] private int _speedRecovery;

    private void OnEnable()
    {
        MaxValue = PlayerData.Stats.Mana;
        CurrentValue = MaxValue;
    }

    private void Update()
    {
        CurrentValue += _speedRecovery * Time.deltaTime;

        if (CurrentValue > MaxValue)
        {
            CurrentValue = MaxValue;
        }
    }

    public void Reduce(float cost)
    {
        if (CurrentValue > 0)
        {
            if (cost < 0)
            {
                cost = 0;
            }
        }

        if (cost > 0)
        {
            CurrentValue -= cost;

            if (CurrentValue <= 0)
            {
                CurrentValue = 0;
            }
        }
    }
}
