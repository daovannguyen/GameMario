using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGameScreen : PauseScreen
{
    public override void OnClickContinuButton()
    {
        int curLevel = PlayerPrefs.GetInt(Constrain.PP_LevelSelected);
        curLevel++;
        Time.timeScale = 1;
        PlayerPrefs.SetInt(Constrain.PP_LevelSelected, curLevel);
        SceneManager.LoadScene(Constrain.SN_GAME);
        SceneManager.LoadScene(Constrain.SN_LEVELX + (curLevel), LoadSceneMode.Additive);
    }
}
