using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public List<GameObject> playerPrefabs;    
    private void Start()
    {
        int index = PlayerPrefs.GetInt(Constrain.PP_IndexCharatorSelected);
        Instantiate(playerPrefabs[index], Vector2.zero, Quaternion.identity);
    }
}
