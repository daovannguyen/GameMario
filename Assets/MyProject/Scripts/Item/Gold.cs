using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int valueCoin = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnEnterPlayer();
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        OnEnterPlayer();
    //    }
    //}
    public  void OnEnterPlayer()
    {
        gameObject.SetActive(false);
        EventManager.TurnOnAudio(SoundName.PLAYER_HITGOLD, false);
        EventManager.ReceiveScore?.Invoke(valueCoin);
    }
}
