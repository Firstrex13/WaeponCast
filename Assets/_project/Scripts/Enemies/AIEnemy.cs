using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] protected NavMeshAgent Agent;
    [SerializeField] protected EnemyAnimations Animations;
    [SerializeField] protected float AttackSpeed;

    protected float DistanceToAttack = 2f;
    protected Coroutine CheckDistance;
    protected Coroutine Attack;

    protected WaitForSeconds Delay;

    public virtual void Initialize(Player player)
    {
        Player = player;
    }

    public void GoToTarget(Vector3 position)
    {
        Agent.SetDestination(position);
        Animations.PlayRun();

        if (CheckDistance != null)
        {
            StopCoroutine(CheckDistance);
        }

        CheckDistance = StartCoroutine(CheckDistanceCoroutine(position));
    }

    private IEnumerator CheckDistanceCoroutine(Vector3 position)
    {
        yield return null;

        while (Agent.remainingDistance > DistanceToAttack)
        {
            yield return null;
        }

        CheckDistance = null;
        Animations.PlayIdle();
    }

    public IEnumerator AttackCoroutine()
    {
        Delay = new WaitForSeconds(AttackSpeed);

        while (Agent.remainingDistance < DistanceToAttack)
        {
            Animations.PlayAttack();
            yield return Delay;
        }

        Attack = null;
    }

    public void MakeDisable()
    {
        enabled = false;
        Agent.ResetPath();
    }

    public void MakeEnable()
    {
        enabled = true;
    }

}
