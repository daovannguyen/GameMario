using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenFlips : GetCompoment2D
{
    private const string FLIPTAG = "Flip";

    [Header("MoveBetweenFlips")]
    public Vector2 speed;
    public Vector2 curSpeed;
    public bool flipX;
    public override void Awake()
    {
        base.Awake();
        sprite.flipX = flipX;
        curSpeed = speed;
        rb.gravityScale = 1;
        if (speed.y != 0)
        {
            rb.gravityScale = 0;
        }
        AddVelocity();
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(FLIPTAG))
        {
            OnTriggerEnterFlip();
        }
    }
    public virtual void OnTriggerEnterFlip()
    {
        Flip();
    }
    private void Flip()
    {
        curSpeed *= -1;
        AddVelocity();
    }
    private void AddVelocity()
    {
        rb.velocity = curSpeed;
    }
    private void Update()
    {
        int flipXX = flipX ? 1 : -1;
        if(flipXX * rb.velocity.x < 0)
        {
            flipX = !flipX;
            sprite.flipX = flipX;

        }
    }
}