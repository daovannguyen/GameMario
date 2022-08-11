using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int timeLife = 1;
    public int valueCoin = 10;
    private void Awake()
    {
        Invoke("DestroyObject", timeLife);
        EventManager.TurnOnAudio(SoundName.PLAYER_HITGOLD, false);
        EventManager.ReceiveScore?.Invoke(valueCoin);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
