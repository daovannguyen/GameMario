using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int damge = 1;

    public Vector2 curVelocity;
    public Collider2D col;
    public Animator anim;
    public Rigidbody2D rb;
    public bool flipShape;
    public LayerMask groundLayer;
    public bool isAttack;
    public float attackAfterSecond = 10f;

    protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isAttack = true;
    }
    public abstract void Move();
    public abstract void Die();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnEnterPlayer(collision);
        }
        if (collision.transform.CompareTag("Flip"))
        {
            OnEnterFlip();
        }
        if (collision.transform.CompareTag("Map"))
        {
            OnEnterMap();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnStayPlayer(collision);
        }
    }
    public virtual void OnStayPlayer(Collision2D collision)
    {

    }
    public virtual void OnEnterFlip()
    {
        Flip();
    }
    public virtual void OnEnterPlayer(Collider2D collision)
    {
        if (isAttack)
        {
            EventManager.ReceiveGrowth?.Invoke(-damge);
            isAttack = false;
            Invoke("TurnAttack", attackAfterSecond);
        }
    }

    public void TurnAttack()
    {
        isAttack = true;
    }

    public abstract void OnEnterMap();
    public abstract void OnExitMap();
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Map"))
        {
            OnExitMap();
        }
    }

    public virtual void Flip()
    {
        // đảo ngược hình
        if (flipShape)
        {
            var localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        // đảo ngược vận tốc
        curVelocity *= -1;
        AddVelocity();
    }
    private void AddVelocity()
    {
        rb.velocity = curVelocity;
    }
}
