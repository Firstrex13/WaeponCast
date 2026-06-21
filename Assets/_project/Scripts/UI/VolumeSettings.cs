using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using YG;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _musicMixer;

    public Volume Volume;
    private Toggle _toggle;
    private Slider _slider;
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

        Volume = new Volume();
        Volume.CurrentValue = 1;

        Volume.SetValue(Volume.CurrentValue, _masterMixer);
        _slider.value = Volume.CurrentValue;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        _toggle.onValueChanged.RemoveListener(ToggleMusic);
        _slider.onValueChanged.RemoveListener(ChangeValue);
        Unpaused?.Invoke();
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            Volume.SetValue(_minValue, _musicMixer);
        }
        else
        {
            Volume.SetValue(_maxValue, _musicMixer);
        }

        SaveGame();
    }

    public void ChangeValue(float value)
    {
        Volume.SetValue(value, _masterMixer);
        Volume.CurrentValue = value;
        SaveGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(Volume.CurrentValue);
        YG2.saves.Json = json;
        YG2.SaveProgress();
    }
}
