using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFllower : MonoBehaviour
{
    public float speed = 3;
    public GameObject points;
    private List<GameObject> listPoints;
    private int indexNextPoint = 1;
    private bool chieuDi;
    private void Awake()
    {
        listPoints = GetAllChildObject();
        transform.position = listPoints[indexNextPoint - 1].transform.position;
        chieuDi = true;
    }
    public List<GameObject> GetAllChildObject()
    {
        List<GameObject> listChild = new List<GameObject>();
        for (int i = 0; i < points.transform.childCount; i++)
        {
            listChild.Add(points.transform.GetChild(i).gameObject);
        }
        return listChild;
    }
    private void Update()
    {
        GetChieuDi();
        Move2Point();
    }
    private void Move2Point()
    {
        transform.position = Vector2.MoveTowards(
                transform.position,
                listPoints[indexNextPoint].transform.position,
                speed * Time.deltaTime
            );
    }
    private void GetChieuDi()
    {
        if (chieuDi && Vector2.Distance(transform.position, listPoints[indexNextPoint].transform.position) < 0.2f)
        {
            indexNextPoint++;
        }
        if (!chieuDi && Vector2.Distance(transform.position, listPoints[indexNextPoint].transform.position) < 0.2f)
        {
            indexNextPoint--;
        }
        if (indexNextPoint >= listPoints.Count)
        {
            chieuDi = false;
            indexNextPoint = listPoints.Count - 2;
        }
        else if (indexNextPoint <= -1)
        {
            chieuDi = true;
            indexNextPoint = 1;
        }
    }

}
