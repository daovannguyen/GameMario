using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ButtonStartGame : GetCompoment2D
{
    private class AnimState
    {
        public const string NORMAL = "Normal";
        public const string ZEROSTAR = "ZeroStar";
        public const string ONESTAR = "OneStar";
        public const string TWOSTAR = "TwoStar";
        public const string THREESTAR = "ThreeStar";
    }
    public int level;
    public TMP_Text txtLevel;
    private Button btnLevel;

    public override void Awake()
    {
        base.Awake();
        btnLevel = GetComponent<Button>();
    }
    public void InitButton()
    {
        //PlayerPrefs.SetInt(Constrain.PP_LevelXStar + level, 0);
        int star = PlayerPrefs.GetInt(Constrain.PP_LevelXStar + level);
        if (level == 1 && star == 0)
        {
            star = 1;
            PlayerPrefs.SetInt(Constrain.PP_LevelXStar + level, 1);
        }

        // trường hợp cho chơi
        if (star != 0)
        {
            btnLevel.onClick.AddListener(OpenLevel);
        }
        txtLevel.text = $"Level {level}";
        GetStateLevel(star);
    }
    public void GetStateLevel(int star)
    {
        switch (star) 
        {
            case 0: anim.Play(AnimState.NORMAL); break;
            case 1: anim.Play(AnimState.ZEROSTAR); break;
            case 2: anim.Play(AnimState.ONESTAR); break;
            case 3: anim.Play(AnimState.TWOSTAR); break;
            case 4: anim.Play(AnimState.THREESTAR); break;
        }
    }

    private void OpenLevel()
    {
        PlayerPrefs.SetInt(Constrain.PP_LevelSelected, level) ;
        SceneManager.LoadScene(Constrain.SN_GAME);
        SceneManager.LoadScene(Constrain.SN_LEVELX + level, LoadSceneMode.Additive);
    }
}
