using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SelectLevelUI : Singleton<SelectLevelUI>
{
    public GameObject girdLevel;
    public GameObject btnStartPrefab;
    private void Awake()
    {
        for (int i = 1; i< 11; i++)
        {
            GameObject btn = Instantiate(btnStartPrefab, Vector3.zero, Quaternion.identity);
            btn.transform.parent = girdLevel.transform;
            btn.GetComponent<ButtonStartGame>().level = i;
            btn.GetComponent<ButtonStartGame>().InitButton();

        }
    } 
}
