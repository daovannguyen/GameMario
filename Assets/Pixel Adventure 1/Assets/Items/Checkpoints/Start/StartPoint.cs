using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : GetCompoment2D
{
    private class AnimState
    {
        public const string IDLE = "StartPoint_Idle";
        public const string COLLISIONPLAYER = "StartPoint_CollsionPlayer";
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(Constrain.TAG_PLAYER))
        {
            anim.Play(AnimState.COLLISIONPLAYER);
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.transform.CompareTag(Constrain.TAG_PLAYER))
    //    {
    //        anim.Play(AnimState.IDLE);
    //    }
    //}
}
