using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class StatsUpgraderOnButton : MonoBehaviour
{
    [SerializeField] private GameSaver _saver;
    [SerializeField] protected int UpgradeCost;
    [SerializeField] protected TextMeshProUGUI CurrentStat;
    [SerializeField] protected TextMeshProUGUI NextLevelStat;
    [SerializeField] protected TextMeshProUGUI NotEnoughCoinsText;
    [SerializeField] protected TextMeshProUGUI Cost;

    protected IProgressService ProgressService;
    protected CoinCounter CoinCounter;

    private WaitForSeconds _delay;

    private Coroutine _coroutine;

    public virtual void UpgradeStat()
    {
        _saver.SaveGame();
    }

    public virtual void UpdateDisplay() { }

    [Inject]
    public void Construct(IProgressService progress)
    {
        ProgressService = progress;
        CoinCounter = progress.GetProgress().Counter;
    }

    protected void ShowNotEnoghMoneyText()
    {
        if(_coroutine != null)
        {
            StopCoroutine( _coroutine );
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
}
