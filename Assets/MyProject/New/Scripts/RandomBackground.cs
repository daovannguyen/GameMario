using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    public GameObject model;
    private void Awake()
    {
        GameObject background = Instantiate(model, Vector2.zero, Quaternion.identity);
        int childcount = background.transform.childCount;
        for (int i = 0; i < childcount; i++){
            background.transform.GetChild(i).gameObject.SetActive(false);
        }
        int randomindex = Random.Range(0, childcount - 1);
        background.transform.GetChild(randomindex).gameObject.SetActive(true);
    }
}
