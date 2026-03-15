using UnityEngine;
using UnityEngine.Audio;

public class Volume 
{
    private float _minValue = -80f;

    public void SetValue(float value, AudioMixerGroup mixerGroup)
    {
        if (value == 0)
        {
            mixerGroup.audioMixer.SetFloat(mixerGroup.name, _minValue);
        }
        else
        {
            mixerGroup.audioMixer.SetFloat(mixerGroup.name, Mathf.Log10(value) * 20);
        }
    }
}
