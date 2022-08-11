using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public TMP_Text txtScore;
    public int score = 0;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != Constrain.SN_START)
        {
            txtScore.text = "Score: " + score;
        }
        else
        {
            txtScore.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        EventManager.ReceiveScore += ReceiveScoreHandel;
    }
    private void OnDisable()
    {
        EventManager.ReceiveScore -= ReceiveScoreHandel;
    }

    private void ReceiveScoreHandel(int _score)
    {
        score += _score;
        txtScore.text = "Score: " + score;
    }
}
