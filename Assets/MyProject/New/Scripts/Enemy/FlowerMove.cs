using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlowerMove : MonoBehaviour
{
    public Transform top, bot;
    public float timeMove = 4;
    private void Awake()
    {
    }
    private void OnEnable()
    {
        StartCoroutine(IEMove());
    }

    IEnumerator IEMove()
    {
        while (true)
        {
            yield return transform.DOLocalMove(top.localPosition, timeMove).WaitForCompletion();
            yield return new WaitForSeconds(1);
            yield return transform.DOLocalMove(bot.localPosition, timeMove).WaitForCompletion();
            yield return new WaitForSeconds(1);
        }
    }
}
