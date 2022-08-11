using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectCharactor : MonoBehaviour
{

    public List<GameObject> modelPrefabs;

    [HideInInspector]
    public List<GameObject> modelObjs;
    [HideInInspector]
    public int indexModel;
    [HideInInspector]
    public GameObject modelSelected;

    public Button Left_Btn;
    public Button Right_Btn;

    public Vector2 modelPosition = Vector2.zero;
    void Init()
    {
        indexModel = PlayerPrefs.GetInt(Constrain.PP_IndexCharatorSelected);
        modelObjs = new List<GameObject>();
    }
    void CreateAllModelObjs()
    {
        foreach (var i in modelPrefabs)
        {
            GameObject model = Instantiate(i, modelPosition, Quaternion.identity);
            modelObjs.Add(model);
        }
    }
    private void Awake()
    {
        Init();
        CreateAllModelObjs();
    }
    void Start()
    {
        DisplayModel(indexModel);
        Left_Btn.onClick.AddListener(OnClickLeftButton);
        Right_Btn.onClick.AddListener(OnClickRightButton);
    }
    void DisplayModel(int index)
    {
        foreach (var i in modelObjs)
        {
            i.SetActive(false);
        }
        modelObjs[index].SetActive(true);
        indexModel = index;
        modelSelected = modelObjs[index].gameObject;
        PlayerPrefs.SetInt(Constrain.PP_IndexCharatorSelected, indexModel);
    }
    void ChangeCharactor(int change)
    {
        indexModel += change;
        if (indexModel < 0)
            indexModel = modelObjs.Count - 1;
        else if (indexModel >= modelObjs.Count)
            indexModel = 0;
        DisplayModel(indexModel);
    }
    void OnClickLeftButton()
    {
        ChangeCharactor(-1);
    }
    void OnClickRightButton()
    {
        ChangeCharactor(+1);
    }

}