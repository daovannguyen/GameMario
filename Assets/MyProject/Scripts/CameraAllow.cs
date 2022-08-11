using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAllow : MonoBehaviour
{
    private GameObject player;
    private Vector3 distance;
    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            if (distance == Vector3.zero && player.GetComponent<PlayerMovement1>().IsGround())
            {
                distance = transform.position - player.transform.position;
                distance.z = transform.position.z;
            }
            transform.position = new Vector3(player.transform.position.x + distance.x,
                    transform.position.y,
                    transform.position.z
                );

        }
    }
}
