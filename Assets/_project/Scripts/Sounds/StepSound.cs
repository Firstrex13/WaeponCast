using UnityEngine;

public class StepSound : MonoBehaviour
{
    [SerializeField] private AudioSource _stepSound;

    public void Play()
    {
        _stepSound.pitch = Random.Range(0.90f, 1.10f);
        _stepSound.Play();
    }
}
