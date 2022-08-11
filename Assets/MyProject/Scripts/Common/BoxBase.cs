using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeItem
{
    NONE,
    COIN,
    GROWTH
}
public class BoxBase : MonoBehaviour
{
    // sate
    public const string IDLE = "Idle";
    public const string VACHAM = "VaCham";


    private Collider2D collider;
    private Animator anim;
    public bool canBroken = false;
    float distanceBelow = 0.3f;

    [Header("Item")]
    public Transform spawnItemPositon;
    public int countItem = 1;
    public TypeItem curItem;
    public GameObject[] ItemsList;
    public GameObject CoinPrefab;
    public GameObject GrowthPrefab;

    public LayerMask layerEnemy;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        InitItemList();
    }
    void InitItemList()
    {
        ItemsList = new GameObject[10];
        ItemsList[(int)TypeItem.COIN] = CoinPrefab;
        ItemsList[(int)TypeItem.GROWTH] = GrowthPrefab;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            bool checkPlayerVer = Mathf.Abs(collision.collider.bounds.center.x - collider.bounds.center.x) < distanceBelow;
            bool checkPlayerHor = (collision.collider.bounds.center.y - collider.bounds.center.y) < 0f;
            if (checkPlayerHor && checkPlayerVer)
            {
                anim.Play(VACHAM);
                if (countItem > 0 && curItem != TypeItem.NONE)
                {
                    Instantiate(ItemsList[(int)curItem], spawnItemPositon.position, Quaternion.identity);
                    countItem--;
                }
                KillEnemy();
                BrokenByPlayer();
            }
        }
    }
    private void Update()
    {
        //Debug.DrawRay(collider.bounds.center, Vector2.up * 10f, Color.green);
    }
    private void BrokenByPlayer()
    {
        if (canBroken)
        {
            if (PlayerCtrl.Instance.health > 1)
            {
                Broken();
            }
        }
    }

    private void Broken()
    {
        anim.Play(VACHAM);
        //Physics2D.IgnoreCollision()
        Destroy(collider);
        Invoke("SetHidden", 0.5f);
    }
    public void SetHidden()
    {
        gameObject.SetActive(false);
    }
    private void KillEnemy()
    {
        RaycastHit2D hit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.up, 10f, layerEnemy);
        if (hit.collider != null && hit.transform.CompareTag(Constrain.TAG_ENEMY))
        {
            Destroy(hit.collider.gameObject);
            EventManager.TurnOnAudio?.Invoke(SoundName.PLAYER_KILLENEMY, false);
        }
    }
}
