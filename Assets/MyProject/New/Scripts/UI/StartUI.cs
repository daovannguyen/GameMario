using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public Button btnNext;
    private void Awake()
    {
        btnNext.onClick.AddListener(OpenScene);
        EventManager.TurnOnAudio(SoundName.INGAME, true);
    }

    private void OpenScene()
    {
        SceneManager.LoadScene(Constrain.SN_SELECTLEVEL);
    }
}
