using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharatorUI : MonoBehaviour
{
    public Button btnNext;
    // Start is called before the first frame update
    void Start()
    {
        btnNext.onClick.AddListener(OpenSceneSelectLevel);
    }

    private void OpenSceneSelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
