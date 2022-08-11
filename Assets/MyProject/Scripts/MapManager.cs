using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private GameObject player;
    private Vector3 distance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Collider2D _collider = player.GetComponent<Collider2D>();
        Debug.Log(_collider.bounds.center);
        Debug.Log(_collider.bounds.size);
    }

}
