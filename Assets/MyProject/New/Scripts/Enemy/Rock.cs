using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : EnemyBase4
{
    #region Override
    public override void AttackPlayer()
    {
        base.AttackPlayer();
    }

    public override void AttackPlayerAfterSecond(float second)
    {
        base.AttackPlayerAfterSecond(second);
    }

    public override bool CheckPlayerOnEnemy()
    {
        return base.CheckPlayerOnEnemy();
    }

    public override void Die()
    {
        base.Die();
    }

    public override void SetStateEnemy(string enemyState)
    {
        base.SetStateEnemy(enemyState);
    }

    public override void TurnOffCollisionWithPlayer()
    {
        base.TurnOffCollisionWithPlayer();
    }

    public override void TurnOnCollisionWithPlayer()
    {
        base.TurnOnCollisionWithPlayer();
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!CheckPlayerOnEnemy())
            {
                AttackPlayer();
                SetStateEnemy(EnemyState.HIT);
                TurnOffCollisionWithPlayer();
                AttackPlayerAfterSecond(1);
            }
            else
            {
                Die();
            }
        }
    }
}