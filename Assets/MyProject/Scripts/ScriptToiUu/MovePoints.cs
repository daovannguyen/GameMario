using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private int indexNext;
    private bool chieuDi;
    private void Start()
    {
        transform.position = points[0].position;
        chieuDi = true;
        indexNext = 1;
    }
    private void Update()
    {
        if (chieuDi && Vector2.Distance(transform.position, points[indexNext].position) < 0.2f)
        {
            indexNext++;
        }
        if (!chieuDi && Vector2.Distance(transform.position, points[indexNext].position) < 0.2f)
        {
            indexNext--;
        }
        if (indexNext >= points.Length)
        {
            chieuDi = false;
            indexNext = points.Length - 2;
        }
        else if (indexNext <= -1)
        {
            chieuDi = true;
            indexNext = 1;
        }
        Move2Point();
    }
    private void Move2Point()
    {
        transform.position = Vector2.MoveTowards(
                transform.position,
                points[indexNext].position,
                speed * Time.deltaTime
            );
    }
}
