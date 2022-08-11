using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;



public class PlayerLife : MonoBehaviour
{

    private PlayerControler pctrl;
    public float health = 1;
    private void OnEnable()
    {
        EventManager.AttackPlayer += AttackPlayerHandle;
    }
    private void OnDisable()
    {
        EventManager.AttackPlayer -= AttackPlayerHandle;
    }

    private void AttackPlayerHandle(float damge)
    {
        health -= damge;
        if (damge > 0)
        {
            StartCoroutine(IENhapNhayPlayer());
        }
        if (health > 0)
        {
            float scale = (health - 1) * 0.3f + 1;
            Vector2 localScale = pctrl.gameObject.transform.localScale;
            Vector2 unitVector = new Vector2(1, 1);
            unitVector.x = (localScale.x > 0) ? 1 : -1;
            unitVector.y = (localScale.y > 0) ? 1 : -1;
            pctrl.gameObject.transform.DOScale(scale * unitVector, 1f);
            //pctrl.gameObject.transform.localScale = scale * unitVector;
        }


        if (health <= 0)
        {
            Die();
            EventManager.EndGame?.Invoke(false);
        }
    }
    IEnumerator IENhapNhayPlayer()
    {
        float timeFrame = 0.2f;
        for(int i=0; i<3; i++)
        {
            yield return pctrl.sprite.DOFade(0, timeFrame).WaitForCompletion();
            yield return pctrl.sprite.DOFade(1, timeFrame).WaitForCompletion();
        }
    }
    private void Awake()
    {
        pctrl = GetComponent<PlayerControler>();
    }
    private void Die()
    {
        pctrl.anim.Play("Player_Die");
        //Destroy(pctrl.col);
        pctrl.rb.bodyType = RigidbodyType2D.Static;
        pctrl.sprite.DOFade(0, 1);
    }
}
