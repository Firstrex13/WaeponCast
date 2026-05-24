using System.Collections;
using UnityEngine;

public enum State
{
    MelleAttack,
    DistanceAttack,
}
public class AIEnemyBoss : AIEnemy
{
    [SerializeField] private int _changeToMelleStatePeriod;
    [SerializeField] private int _changeToDistanceStatePeriod;

    private State _curentState;
    private float _timer;

    private void Start()
    {
        _curentState = State.DistanceAttack;
        _timer = 0f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_curentState == State.DistanceAttack)
        {
            if (Player != null)
            {
                Vector3 direction = Player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);

                if (Attack != null)
                {
                    return;
                }

                Attack = StartCoroutine(DistanceAttackCoroutine());
            }
        }
        else if(_curentState == State.MelleAttack)
        {
            if(_timer > _changeToDistanceStatePeriod)
            {
                ChangeState(State.DistanceAttack);
                _timer = 0;
                return;
            }

            if (Player != null)
            {
                float distanceSquared = Vector3.SqrMagnitude(Player.transform.position - transform.position);

                if (gameObject.activeSelf)
                {
                    if (Animations.CanRun == true)
                    {
                        Agent.SetDestination(Player.transform.position);

                        if (distanceSquared > DistanceToAttack * DistanceToAttack)
                        {
                            GoToTarget(Player.transform.position);
                        }
                        else
                        {
                            if (Attack != null)
                            {
                                StopCoroutine(Attack);
                            }

                            Attack = StartCoroutine(AttackCoroutine());
                        }
                    }
                    else
                    {
                        Agent.ResetPath();
                    }
                }
            }
        }
    }

    public override void Initialize(Player player)
    {
        base.Initialize(player);
    }

    private IEnumerator DistanceAttackCoroutine()
    {
        Delay = new WaitForSeconds(AttackSpeed);

        while (_timer < _changeToMelleStatePeriod)
        {
            yield return Delay;

            Animations.PlayDistanceAttack();
        }

        Attack = null;
        ChangeState(State.MelleAttack);
        _timer = 0;
    }

    private void ChangeState(State state)
    {
        _curentState = state;
    }
}
