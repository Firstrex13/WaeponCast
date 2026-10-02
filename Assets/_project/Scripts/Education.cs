using System.Collections;
using TMPro;
using UnityEngine;

public class Education : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _spawner;
    private bool _isGameplayOn;
    private int _educationTitleNumber;

    private Coroutine _educationCoroutine;

    void Start()
    {
        if (_educationCoroutine != null)
        {
            StopCoroutine(_educationCoroutine);
        }

        StartCoroutine(StartEducation());

    }

    private IEnumerator StartEducation()
    {
        WaitForSeconds delay = new WaitForSeconds(1);

        yield return delay;

        _panel.SetActive(true);
        _text.text = "\tДобро пожаловать в Разряд силы!\r\n\r\n   Для начала давай научимся передвигаться.\r\n\r\nИспользуй клавиши WASD для того чтобы\r\nдвигаться.";
        _isGameplayOn = false;
        _educationTitleNumber = 1;

        while (!_isGameplayOn)
        {
            yield return null;
        }

        yield return delay;
        _panel.SetActive(true);
        _text.text = "Для того чтобы атаковать врага\r\n необходимо подойти на достаточное\r\n расстояние до него. Обрати внимание \r\nчто атаковать можно только\r\n когда персонаж не двигается.";
      
    }

    public void TurnOffPanel()
    {
        if (_educationTitleNumber == 2)
        {
            _panel.SetActive(false);
            _isGameplayOn = true;
            _spawner.SetActive(true);
        }
        else
        {
            _panel.SetActive(false);
            _isGameplayOn = true;
            _educationTitleNumber++;
        }
    }
}
