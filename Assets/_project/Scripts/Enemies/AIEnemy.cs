using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Zenject;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private DragonAnimations _animations;
    [SerializeField] private float _attackSpeed;

    private float _distanceToInteracte = 1.5f;
    private Coroutine _checkDistance;
    private Coroutine _attack;

    private WaitForSeconds _delay;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (_player != null)
        {
            _agent.SetDestination(_player.transform.position);

            if (_agent.remainingDistance > _distanceToInteracte)
            {
                GoToTarget(_player.transform.position);
            }
            else
            {
                if(_attack != null)
                {
                    StopCoroutine(_attack);
                }

               _attack =  StartCoroutine(Attack());
            }
        }
    }

    public void MakeDisable()
    {
        enabled = false;
    }

    private void GoToTarget(Vector3 position)
    {

        _agent.SetDestination(position);
        _animations.PlayRun();

        if (_checkDistance != null)
        {
            StopCoroutine(_checkDistance);
        }

        _checkDistance = StartCoroutine(CheckDistance(position));
    }

    private IEnumerator CheckDistance(Vector3 position)
    {
        yield return null;

        while (_agent.remainingDistance > _distanceToInteracte)
        {
            yield return null;
        }

        _checkDistance = null;
        _animations.PlayIdle();
    }

    private IEnumerator Attack()
    {
        _delay = new WaitForSeconds(_attackSpeed);

        while (_agent.remainingDistance < _distanceToInteracte)
        {
            _animations.PlayAttack();
            yield return _delay;
        }

        _attack = null;
    }
}
