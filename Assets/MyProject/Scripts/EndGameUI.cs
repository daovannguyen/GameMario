using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EndGameUI : MonoBehaviour
{
    public GameObject endGameScreen;
    public TMP_Text txtDiem;
    private void Awake()
    {
        endGameScreen.SetActive(false);
    }
    private void OnEnable()
    {
        EventManager.EndGame += EndGameHandel;
    }
    private void OnDisable()
    {
        EventManager.EndGame -= EndGameHandel;
    }

    private void EndGameHandel(bool obj)
    {
        Invoke("DisplayEndGameScreen", 2);
    }
    private void DisplayEndGameScreen()
    {
        endGameScreen.SetActive(true);
        txtDiem.text = $"Bạn được {PlayerCtrl.Instance.score} điểm";
    }
}
