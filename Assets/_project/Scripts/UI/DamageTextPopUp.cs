using System.Collections;
using TMPro;
using UnityEngine;

public class DamageTextPopUp : MonoBehaviour
{
    private readonly int MoveText = Animator.StringToHash(nameof(MoveText));

    [SerializeField] private TextMeshProUGUI _textPopUp;
    [SerializeField] private Animator _animator;

    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    private void Start()
    {
        _textPopUp.enabled = false;
    }

    public void ShowDamageText(int damage)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

       _coroutine = StartCoroutine(ShowText(damage));
    }

    private IEnumerator ShowText(int damage)
    {
        _delay = new WaitForSeconds(0.5f);
        _animator.SetTrigger(MoveText);
        _textPopUp.enabled = true;
        _textPopUp.text = damage.ToString();
        yield return _delay;
        _textPopUp.enabled = false;
    }
}
