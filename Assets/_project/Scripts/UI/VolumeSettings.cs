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

        if (Volume == null)
        {
            Volume = new Volume();
            Volume.CurrentValue = 1;
        }

        if (PlayerPrefs.HasKey("ToggleMusic"))
        {
            Volume.SetValue(PlayerPrefs.GetInt("ToggleMusic"), _masterMixer);

            if (PlayerPrefs.GetInt("ToggleMusic") == 0)
            {
                _toggle.isOn = true;
            }
            else
            {
                _toggle.isOn = false;
            }
        }

        if (PlayerPrefs.HasKey("VolumeValue"))
        {
            Volume.SetValue(PlayerPrefs.GetFloat("VolumeValue"), _masterMixer);

            _slider.value = PlayerPrefs.GetFloat("VolumeValue");
        }
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
            PlayerPrefs.SetInt("ToggleMusic", 0);
        }
        else
        {
            Volume.SetValue(_maxValue, _musicMixer);
            PlayerPrefs.SetInt("ToggleMusic", 1);
        }
    }

    public void ChangeValue(float value)
    {
        Volume.SetValue(value, _masterMixer);
        Volume.CurrentValue = value;
        PlayerPrefs.SetFloat("VolumeValue", Volume.CurrentValue);
    }
}
