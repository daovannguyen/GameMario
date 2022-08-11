using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : EnemyBase4
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AttackPlayer();
            //SetStateEnemy(EnemyState.HIT);
            TurnOffCollisionWithPlayer();
            AttackPlayerAfterSecond(1);

        }
    }
}
