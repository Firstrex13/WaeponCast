using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private UnitChecker _unitChecker;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AbilityPlayerUser _abillityUser;
    [SerializeField] private Mana _mana;

    private bool _isAttacking;

    private void Update()
    {
        if (_unitChecker.NearestEnemy)
        {
            if (_unitChecker.NearestEnemy.EnemyHealth.CurentHealth > 0)
            {
                if (!_playerController.Moving)
                {
                    if (Time.timeScale > 0)
                    {
                        if (_mana.Current >= _abillityUser.ManaCost)
                        {
                            Attack();
                        }
                    }
                }
            }
        }

        _isAttacking = false;
    }

    private void Attack()
    {
        _isAttacking = true;

        if (_isAttacking == true)
        {
            _animations.PlayThrow();
        }
        else
        {
            return;
        }
    }
}
