using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ====
 ==== Class này có chức năng lưu trữ lại các biến văn bản
 ====
 */
public class Constrain 
{
    #region SceneName
    public const string SN_START = "Start";
    public const string SN_SELECTLEVEL = "SelectLevel";
    public const string SN_GAME = "Game";
    public const string SN_LEVELX = "Level";
    #endregion


    #region TagName
    public const string TAG_PLAYER = "Player";
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_CHECKPOINTEND = "CheckpointEnd";
    public const string TAG_ENDGAMEPOINT = "ENDGAMEPOINT";
    #endregion

    #region PlayerPre
    public const string PP_IndexCharatorSelected = "IndexCharatorSelected";

    // có 4 trạng thái từ 0-4 tương ứng với từ khóa, có thể chơi, 1, 2, 3 sao,
    //PP_LevelXStar + level
    public const string PP_LevelXStar = "StarLevel";
    public const string PP_LevelSelected = "LevelSelected";
    #endregion
}
