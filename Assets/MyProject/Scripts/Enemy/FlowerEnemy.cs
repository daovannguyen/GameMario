using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerEnemy : EnemyBase
{
    public int timewaitFlip = 2;
    //public float distaneDestroy = 0.2f;
    public override void Die()
    {

    }

    public override void Flip()
    {
        base.Flip();
    }

    public override void Move()
    {

    }

    public override void OnEnterMap()
    {
        //rb.velocity = new Vector2(curVelocity.x, 0);
        //rb.gravityScale = 0;
    }

    public override void OnEnterPlayer(Collider2D collision)
    {
        base.OnEnterPlayer(collision);
    }

    public override void OnExitMap()
    {
        rb.gravityScale = 1;
    }

    protected override void Awake()
    {
        base.Awake();
        rb.velocity = curVelocity;
        rb.gravityScale = 0;
    }

    public override void OnEnterFlip()
    {
        rb.velocity = Vector2.zero;
        Invoke("Flip", timewaitFlip);
    }
}
