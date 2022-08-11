using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : ItemBase
{
    public float willScale = 1;
    public override void OnEnterPlayer()
    {
        base.OnEnterPlayer();
        EventManager.TurnOnAudio(SoundName.PLAYER_HITGOLD, false);
        EventManager.AttackPlayer?.Invoke(-willScale);
        Destroy(gameObject);
    }

}
