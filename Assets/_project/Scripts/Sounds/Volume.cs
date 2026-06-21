using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Volume
{
    [HideInInspector] public float MinValue = -80f;
    [HideInInspector] public float CurrentValue;

    public void SetValue(float value, AudioMixerGroup mixerGroup)
    {
        if (value == 0)
        {
            mixerGroup.audioMixer.SetFloat(mixerGroup.name, MinValue);
        }
        else
        {
            mixerGroup.audioMixer.SetFloat(mixerGroup.name, Mathf.Log10(value) * 20);
        }
    }
}
