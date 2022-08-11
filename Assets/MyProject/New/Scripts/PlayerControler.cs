using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : Singleton<PlayerControler>
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public Collider2D col;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
}
