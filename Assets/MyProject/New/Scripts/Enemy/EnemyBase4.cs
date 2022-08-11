using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase4 : MonoBehaviour
{
    protected static class EnemyState
    {
        public static string IDLE = "Enemy_Idle";
        public static string RUN = "Enemy_Run";
        public static string HIT = "Enemy_Hit";
        public static string DIE = "Enemy_Die";
        public static string ATTACK = "Enemy_Attack";
    }
    public float damge;
    public string state;
    public float rangeDestroy;

    public Collider2D col;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        state = EnemyState.RUN;
    }
    public virtual void Die()
    {
        EventManager.TurnOnAudio(SoundName.PLAYER_KILLENEMY, false);
        anim.Play(EnemyState.DIE);
        Destroy(gameObject);

    }
    public virtual void AttackPlayer()
    {
        EventManager.TurnOnAudio(SoundName.PLAYER_HITENEMY, false);
        EventManager.AttackPlayer?.Invoke(damge);
    }
    public virtual void AttackPlayerAfterSecond(float second)
    {
        Invoke("TurnOnCollisionWithPlayer", second);
    }
    public virtual void TurnOffCollisionWithPlayer()
    {
        Physics2D.IgnoreCollision(col, PlayerControler.Instance.col);
    }
    public virtual void TurnOnCollisionWithPlayer()
    {
        Physics2D.IgnoreCollision(col, PlayerControler.Instance.col, false);
    }
    public virtual void SetStateEnemy(string enemyState)
    {
        anim.Play(enemyState);
        state = enemyState;
    }
   
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AttackPlayerAfterSecond(1);
            SetStateEnemy(EnemyState.RUN);
        }
    }

    // collison truyền vào khi va chạm
    public virtual bool CheckPlayerOnEnemy()
    {
        Collider2D pcol = PlayerControler.Instance.col;
        bool hor = Mathf.Abs(pcol.bounds.center.x - col.bounds.center.x) < rangeDestroy;
        bool ver = pcol.bounds.center.y > col.bounds.center.y;
        return ver && hor;
    }
}
