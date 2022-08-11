using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Snail : EnemyBase4
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

    public float maxSpeed = 10f;
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

                TurnOffCollisionWithPlayer();
                AttackPlayerAfterSecond(1);

                anim.Play("");
                SetCurentSpeed(Vector2.zero);
                rb.velocity = Vector2.zero;

                Invoke("SpeedUpMax", 2);
            }
        }
    }
    public void SpeedUpMax()
    {
        SetCurentSpeed(new Vector2(maxSpeed, 0));
        rb.velocity = new Vector2(maxSpeed, 0);

        // về vận tốc ban đầu
        Invoke("SetSpeedNormal", 10);
    }
    private void SetSpeedNormal()
    {
        SetCurentSpeed(GetComponent<MoveBetweenFlips>().speed);
    }
    private void SetCurentSpeed(Vector2 speed)
    {
        GetComponent<MoveBetweenFlips>().curSpeed = speed;
    }
}
