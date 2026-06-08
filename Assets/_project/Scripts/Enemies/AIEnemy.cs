using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] protected Player Player;
    [SerializeField] protected NavMeshAgent Agent;
    [SerializeField] protected EnemyAnimations Animations;
    [SerializeField] protected float AttackSpeed;
    [SerializeField] protected float DistanceToAttack = 2f;

    protected Coroutine CheckDistance;
    protected Coroutine Attack;

    protected WaitForSeconds Delay;

    protected float AttackTimer;

    public virtual void Initialize(Player player)
    {
        Player = player;
    }

    public void GoToTarget(Vector3 position)
    {
        Agent.SetDestination(position);
        Animations.PlayRun();
    }

    public IEnumerator AttackCoroutine()
    {
        Animations.PlayAttack();
        yield return null;
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
