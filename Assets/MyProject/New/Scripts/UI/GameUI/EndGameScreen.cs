using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : PauseScreen
{
    public override void Awake()
    {
        btnRestart.onClick.AddListener(OnClickRestartButton);
        btnMainMenu.onClick.AddListener(OnClickMainMenuButton);
    }
}
