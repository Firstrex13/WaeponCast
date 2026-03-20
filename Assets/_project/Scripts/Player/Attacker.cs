using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private AudioSource _throwSound;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AbillityUser _abillityUser;

    private WaitForSecondsRealtime _delay;
    private Coroutine _throw;
    private float _timer;

    private void Update()
    {
        if (!_unitChecker.NearestEnemy)
        {
            return;
        }

        if (_playerController.Moving)
        {
            return;
        }

        if (Time.timeScale < 0)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer > _abillityUser.AttackRate)
        {
            Attack();
            _timer = 0;
        }
    }

    private void Attack()
    {
        _animations.PlayThrow();
        _throwSound.Play();
    }
}
