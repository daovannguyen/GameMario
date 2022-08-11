using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : EnemyBase3
{
    public override void Die()
    {
        gameObject.SetActive(false);
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnterPlayer(Collider2D collision)
    {
        if (CheckPlayerOnEnemy(collision))
        {
            Die();
        }
        base.OnCollisionEnterPlayer(collision);
    }


    public override void TurnOnCollisionWithPlayer()
    {
        base.TurnOnCollisionWithPlayer();
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
