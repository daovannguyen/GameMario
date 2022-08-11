using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public static class StatePlayer
{
    public static string IDLE = "Player_Idle";
    public static string HIT = "Player_Hit";
    public static string RUN = "Player_Run";
    public static string JUMP = "Player_Jump";
    //public static string RUN = "Player_Run";
}

public class PlayerMovement : MonoBehaviour
{
    public Button btnLeft;
    public Button btnRight;
    public Button btnUp;


    private float horizontal;
    private float moveSpeed = 3f;
    private float jumpForce = 10f;
    private bool isFacingRight = true;
    [HideInInspector]
    public Transform targetEndGame;
    public float maxDistance = 1;

    
    [SerializeField] private LayerMask groundLayer;
    private string state = StatePlayer.IDLE;

    public bool isControl;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isJump = false;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        SetPlayerState(StatePlayer.IDLE);
        isControl = true;
        btnUp.onClick.AddListener(Jump);
        if(SceneManager.GetActiveScene().name == "Start")
        {
            btnLeft.gameObject.SetActive(false);
            btnRight.gameObject.SetActive(false);
            btnUp.gameObject.SetActive(false);
        }

    }
    private void SetPlayerState(string playerstate)
    {
        anim.Play(playerstate);
        state = playerstate;
    }

    public void OnPointDownLeft()
    {
        horizontal = -1f;
        PlayerCtrl.Instance.rb.velocity = new Vector2(horizontal * moveSpeed, PlayerCtrl.Instance.rb.velocity.y);
    }

    public void OnPointUpLeft()
    {
        horizontal = 0;
        PlayerCtrl.Instance.rb.velocity = new Vector2(horizontal * moveSpeed, PlayerCtrl.Instance.rb.velocity.y);
    }
    public void OnPointUpRight()
    {
        horizontal = 0;
        PlayerCtrl.Instance.rb.velocity = new Vector2(horizontal * moveSpeed, PlayerCtrl.Instance.rb.velocity.y);
    }

    public void OnPointDownRight()
    {
        horizontal = 1f;
        PlayerCtrl.Instance.rb.velocity = new Vector2(horizontal * moveSpeed, PlayerCtrl.Instance.rb.velocity.y);
    }


    private void Jump()
    {
        if (isControl)
        {
            if (IsGrounded())
            {
                PlayerCtrl.Instance.rb.velocity = new Vector2(PlayerCtrl.Instance.rb.velocity.x, jumpForce);
            }
            if (PlayerCtrl.Instance.rb.velocity.y > 0f)
            {
                PlayerCtrl.Instance.rb.velocity = new Vector2(PlayerCtrl.Instance.rb.velocity.x, PlayerCtrl.Instance.rb.velocity.y);
            }
        }
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // di chuyển sang phải
        if (horizontal > 0)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            sprite.flipX = false;
        }
        // di chuyển sang trái
        if (horizontal < 0)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            sprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else
        {
            isJump = false;
        }
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        if (isControl)
        {
            

        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, targetEndGame.position, maxDistance);
        }
    }
    private bool IsGrounded()
    {
        float mm = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(
                PlayerCtrl.Instance.col.bounds.center,
                PlayerCtrl.Instance.col.bounds.size,
                0f,
                Vector2.down,
                mm,
                groundLayer
            );
        return raycastHit.collider != null;
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }    
    }
    private void UpdateAnimation()
    {
        if (isJump && state != StatePlayer.JUMP)
        {
            SetPlayerState(StatePlayer.JUMP);
        }
        else if (horizontal != 0f && state != StatePlayer.RUN)
        {
            SetPlayerState(StatePlayer.RUN);
        }
        else if (horizontal == 0 && state != StatePlayer.IDLE)
        {
            SetPlayerState(StatePlayer.IDLE);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

        }
        if (collision.transform.CompareTag("CheckpointEnd"))
        {
            OnEnterCheckpointEnd(collision);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {

        }
    }
    private void OnEnterCheckpointEnd(Collider2D collision)
    {
        isControl = false;
        PlayerCtrl.Instance.rb.velocity = new Vector2(0, 0); 
        PlayerCtrl.Instance.anim.Play(StatePlayer.RUN);
        state = StatePlayer.RUN;
        targetEndGame = collision.transform.GetComponent<CheckpointEnd>().targetEnd;
    }
}
