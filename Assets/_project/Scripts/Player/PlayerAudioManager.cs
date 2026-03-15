using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _hitSound;

    public void PlayHit()
    {
        _hitSound.Play();
    }
}
