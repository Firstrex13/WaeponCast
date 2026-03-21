using UnityEngine;

public class StepSound : MonoBehaviour
{
    [SerializeField] private AudioSource _stepSound;

    public void Play()
    {
        _stepSound.Play();
    }
}
