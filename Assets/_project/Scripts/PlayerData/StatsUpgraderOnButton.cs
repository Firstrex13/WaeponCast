using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class StatsUpgraderOnButton : MonoBehaviour
{
    private const string HEALTH_STAT = "_healthStat";
    private const string MANA_STAT = "_manaStat";
    private const string FORECE_STAT = "_forceStat";
    private const string ATTACK_RATE_STAT = "_attackRateStat";
    private const string MANA_RECOVERY_SPEED_STAT = "_manaRecoverySpeedStat";
    private const string MAX_VALUE = "Max";

    [SerializeField] private GameSaver _saver;
    [SerializeField] private int UpgradeCost;
    [SerializeField] private TextMeshProUGUI CurrentStat;
    [SerializeField] private TextMeshProUGUI NotEnoughCoinsText;
    [SerializeField] private TextMeshProUGUI Cost;
    [SerializeField] private string _stat;
    [SerializeField] private WeaponConfig _weaponConfig;

    private IProgressService ProgressService;
    private CoinCounter CoinCounter;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;


    private void OnEnable()
    {
        UpdateStatsDisplay(_stat);
    }

    public void UpgradeStatOnButton(string stat)
    {
        _stat = stat;
        if (CoinCounter.TotalCoinCount >= UpgradeCost)
        {
            ProgressService.GetProgress().Stats.UpgradeStat(stat);
            ProgressService.GetProgress().Counter.DecreaseCoin(UpgradeCost);
            UpdateStatsDisplay(stat);
        }
        else
        {
            ShowNotEnoghMoneyText();
            UpdateStatsDisplay(stat);
        }

        _saver.SaveGame();
    }

    [Inject]
    public void Construct(IProgressService progress)
    {
        ProgressService = progress;
        CoinCounter = progress.GetProgress().Counter;
    }

    private void ShowNotEnoghMoneyText()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(PopUpText());
    }

    private IEnumerator PopUpText()
    {
        _delay = new WaitForSeconds(0.08f);

        NotEnoughCoinsText.alpha = 1.0f;

        while (NotEnoughCoinsText.alpha > 0.0f)
        {
            NotEnoughCoinsText.alpha -= 0.1f;
            yield return _delay;
        }
    }

    private void UpdateStatsDisplay(string stat)
    {
        switch (stat)
        {
            case HEALTH_STAT:
                CurrentStat.text = ProgressService.GetProgress().Stats.Health.ToString();
                Cost.text = UpgradeCost.ToString();
                break;
            case MANA_STAT:
                CurrentStat.text = ProgressService.GetProgress().Stats.Mana.ToString();
                Cost.text = UpgradeCost.ToString();
                break;
            case FORECE_STAT:
                CurrentStat.text = (_weaponConfig.Damage + ProgressService.GetProgress().Stats.Force).ToString();
                Cost.text = UpgradeCost.ToString();
                break;
            case ATTACK_RATE_STAT:
                float value = 1 + ProgressService.GetProgress().Stats.AttackRate;
                CurrentStat.text = value.ToString();
                if(value == 2)
                {
                    CurrentStat.text = MAX_VALUE;
                }
                Cost.text = UpgradeCost.ToString();
                break;
            case MANA_RECOVERY_SPEED_STAT:
                CurrentStat.text = ProgressService.GetProgress().Stats.ManaRecoverySpeed.ToString();
                Cost.text = UpgradeCost.ToString();
                break;
            default:
                break;
        }
    }
}
