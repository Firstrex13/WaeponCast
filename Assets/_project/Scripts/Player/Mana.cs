using UnityEngine;

public class Mana : BarComponent
{
    [SerializeField] private int _speedRecovery;

    private PlayerProgress _playerProgress;

    public void Initialize(IProgressService playerProgress)
    {
        _playerProgress = playerProgress.GetProgress();
    }
    
    private void Start()
    {
        MaxValue =  _playerProgress.Stats.Mana;
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
