using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase3 : MonoBehaviour
{
    public float damge;
    public float timeAttackNext;
    public float distaneDestroy;


    public Collider2D col;
    public Animator anim;
    public Rigidbody2D rb;

    protected virtual void Awake()
    {
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public abstract void Move();
    public abstract void Die();
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        Debug.Log("fhsakfda");
    //        OnCollisionEnterPlayer(collision);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("fhsakfda");
            OnCollisionEnterPlayer(collision);
        }
    }
    public virtual void OnCollisionEnterPlayer(Collider2D collision)
    {
        EventManager.ReceiveGrowth?.Invoke(-damge);
        Physics2D.IgnoreCollision(col, collision);
        Invoke("TurnOnCollisionWithPlayer", timeAttackNext);
    }
    public virtual void TurnOnCollisionWithPlayer()
    {
        Physics2D.IgnoreCollision(col, PlayerCtrl.Instance.col, false);
    }
    public bool CheckPlayerOnEnemy(Collider2D collision)
    {
        bool ver = Mathf.Abs(collision.bounds.center.x - col.bounds.center.x) < distaneDestroy;
        bool hor = collision.bounds.center.y > col.bounds.center.y;
        return ver && hor;
    }
}
