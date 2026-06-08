using UnityEngine;

public class AIEnemyUnit : AIEnemy
{
    private void Start()
    {
        AttackTimer = 0;
    }
    private void Update()
    {
        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
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
                        if(AttackTimer > 0)
                        {
                            return;
                        }

                        if (Attack != null)
                        {
                            StopCoroutine(Attack);
                        }

                        Attack = StartCoroutine(AttackCoroutine());
                        AttackTimer = AttackSpeed;
                    }
                }
                else
                {
                    Agent.ResetPath();
                }
            }
        }
        else
        {
            Agent.ResetPath();
            Animations.PlayIdle();
        }
    }

    public override void Initialize(Player player)
    {
        base.Initialize(player);
        Agent.SetDestination(Player.transform.position);
    }
}
