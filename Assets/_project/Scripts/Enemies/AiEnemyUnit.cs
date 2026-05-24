using UnityEngine;

public class AIEnemyUnit : AIEnemy
{
    private void Update()
    {
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

    public override void Initialize(Player player)
    {
        base.Initialize(player);
        Agent.SetDestination(Player.transform.position);
    }
}
