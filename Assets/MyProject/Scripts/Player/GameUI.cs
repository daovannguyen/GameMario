using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : Singleton<GameUI>
{
    [Header("Game UI")]
    public Button btnPause;
    public Button btnComplete;
    public TMP_Text txtScore;

    [Header("Screens")]
    public GameObject pauseScreen;
    public GameObject endGameScreen;
    public GameObject completeScreen;

    int totalCoin = 0;
    private void Awake()
    {
        pauseScreen.SetActive(false);
        endGameScreen.SetActive(false);
        completeScreen.SetActive(false);
        btnPause.onClick.AddListener(OnClickPauseButton);
    }
    private void Start()
    {
        totalCoin = GetTotalCoin();
        Debug.Log(totalCoin);
    }
    private void OnEnable()
    {
        EventManager.ReceiveScore += ReceiveScoreHandle;
        EventManager.EndGame += EndGameHandle;
    }
    private void OnDisable()
    {
        EventManager.ReceiveScore -= ReceiveScoreHandle;
        EventManager.EndGame -= EndGameHandle;
    }

    private void EndGameHandle(bool obj)
    {
        if(obj == false)
        {
            Invoke("DisplayEndGameScreen", 1f);
            EventManager.TurnOnAudio(SoundName.LOSEGAME, false);
        }
        else
        {
            int curLevel = PlayerPrefs.GetInt(Constrain.PP_LevelSelected);
            float score = CalculateScore();
            int star = 0;

            if (score < 1.0f / 4.0)
            {
                star = 0;
            }
            else if (score < 2.0f / 4.0)
            {
                star = 1;
            }
            else if (score < 3.0f / 4.0)
            {
                star = 2;
            }
            else 
            {
                star = 3;
            }
            if (PlayerPrefs.GetInt(Constrain.PP_LevelXStar + (curLevel + 1)) == 0)
            {
                SaveGame(curLevel + 1, 0);
            }
            SaveGame(curLevel, star);
            completeScreen.SetActive(true);
            SetStateButtonComplete(star + 1);
            EventManager.TurnOnAudio(SoundName.WINGAME, false);
        }
    }
    private void SetStateButtonComplete(int star)
    {
        ButtonStartGame buttonStartGame = btnComplete.GetComponent<ButtonStartGame>();
        buttonStartGame.GetStateLevel(star);
    }

    public void SaveGame(int level, int star)
    {
        int curStar = PlayerPrefs.GetInt(Constrain.PP_LevelXStar + level);
        if (curStar < star + 1)
        {
            PlayerPrefs.SetInt(Constrain.PP_LevelXStar + level, star + 1);
        }
    }

    private float CalculateScore()
    {
        // coin còn lại
        int total = GetTotalCoin();
        return 1.0f - (float)(total) / totalCoin;
    }
    public int GetTotalCoin()
    {
        BoxBase[] boxes = GameObject.FindObjectsOfType<BoxBase>();
        Gold[] golds = GameObject.FindObjectsOfType<Gold>();

        int total = 0;
        foreach (BoxBase box in boxes)
        {
            TypeItem type = box.curItem;
            if (type == TypeItem.COIN)
            {
                total += box.countItem * 10;
            }
        }
        foreach (Gold gold in golds)
        {
            total += gold.valueCoin;
        }
        return total;
    }
    private void DisplayEndGameScreen()
    {
        endGameScreen.SetActive(true);
    }

    private void OnClickPauseButton()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    private void ReceiveScoreHandle(int obj)
    {
        PlayerCtrl.Instance.score += obj;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            EventManager.EndGame?.Invoke(true);
        }
    }
}
