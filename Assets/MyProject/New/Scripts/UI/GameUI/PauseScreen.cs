using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public Button btnContinue;
    public Button btnRestart;
    public Button btnMainMenu;
    
    public virtual void Awake()
    {
        btnContinue.onClick.AddListener(OnClickContinuButton);
        btnRestart.onClick.AddListener(OnClickRestartButton);
        btnMainMenu.onClick.AddListener(OnClickMainMenuButton);
    }

    public void OnClickMainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constrain.SN_START);
    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1;
        int curLevel = PlayerPrefs.GetInt(Constrain.PP_LevelSelected);
        PlayerPrefs.SetInt(Constrain.PP_LevelSelected, curLevel);
        SceneManager.LoadScene(Constrain.SN_GAME);
        SceneManager.LoadScene(Constrain.SN_LEVELX + curLevel, LoadSceneMode.Additive);
    }

    public virtual void OnClickContinuButton()
    {
        Time.timeScale = 1;
        GameUI.Instance.pauseScreen.SetActive(false);
    }
}
