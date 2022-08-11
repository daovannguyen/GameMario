using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : EnemyBase3
{
    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnterPlayer(Collider2D collision)
    {
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
