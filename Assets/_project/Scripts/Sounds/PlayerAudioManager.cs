using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    public void PlaySound()
    {
        _sound.Play();
    }
}
