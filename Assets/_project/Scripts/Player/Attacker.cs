using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AbillityUser _abillityUser;
    [SerializeField] private Mana _mana;

    private float _timer;
    private bool _isReadyToAttack = true;

    private void Update()
    {
        if (_unitChecker.NearestEnemy)
        {
            if (!_playerController.Moving)
            {
                if (Time.timeScale > 0)
                {
                    if (_isReadyToAttack && _mana.CurrentValue >= _abillityUser.ManaCost)
                    {
                        Attack();
                        _isReadyToAttack = false;
                        _timer = 0;
                    }
                }
            }
        }

        _timer += Time.deltaTime;
        if (_timer > _abillityUser.AttackRate)
        {
            _isReadyToAttack = true;
        }
    }

    private void Attack()
    {
        _animations.PlayThrow();
    }
}
