using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;

    private Toggle _toggle;
    private Slider _slider;

    private Volume _volume;

    private float _minValue = 0;
    private float _maxValue = 1;

    public event Action IsPaused;
    public event Action Unpaused;

    private void Awake()
    {
        _toggle = GetComponentInChildren<Toggle>();
        _slider = GetComponentInChildren<Slider>();
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        _toggle.onValueChanged.AddListener(ToggleMusic);
        _slider.onValueChanged.AddListener(ChangeValue);
        IsPaused?.Invoke();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
        _slider.onValueChanged.RemoveListener(ChangeValue);
        Unpaused?.Invoke();
    }
    private void Start()
    {
        _volume = new Volume();
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            _volume.SetValue(_minValue, _musicMixer);
        }
        else
        {
            _volume.SetValue(_maxValue, _musicMixer);
        }
    }

    public void ChangeValue(float value)
    {
        _volume.SetValue(value, _masterMixer);
    }
}
