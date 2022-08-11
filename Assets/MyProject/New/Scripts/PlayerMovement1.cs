using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement1 : MonoBehaviour
{
    public Button btnLeft;
    public Button btnRight;
    public Button btnUp;


    private float horizontal;
    public float moveSpeed;
    public float jumpForce;
    private string state = MovementState.IDLE;
    public LayerMask jumpableleGround;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private Collider2D col;


    public bool isControl;
    public Transform targetEndGame;
    public float maxDistance = 0.00005f;

    PlayerControler pctrl;

    private static class MovementState
    {
        public static string IDLE = "Player_Idle";
        public static string HIT = "Player_Hit";
        public static string RUN = "Player_Run";
        public static string JUMP = "Player_Jump";
        public static string FALL = "Player_Fall";
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        pctrl = GetComponent<PlayerControler>();
        isControl = true;


        //btnUp.onClick.AddListener(Jump);
        if(SceneManager.GetActiveScene().name == Constrain.SN_START)
        {
            btnLeft.gameObject.SetActive(false);
            btnRight.gameObject.SetActive(false);
            btnUp.gameObject.SetActive(false);
        }
    }


    public void OnPointDownLeft()
    {
        horizontal = -1f;
        pctrl.rb.velocity = new Vector2(horizontal * moveSpeed, pctrl.rb.velocity.y);
    }

    public void OnPointUpLeft()
    {
        horizontal = 0;
        pctrl.rb.velocity = new Vector2(horizontal * moveSpeed, pctrl.rb.velocity.y);
    }
    public void OnPointUpRight()
    {
        horizontal = 0;
        pctrl.rb.velocity = new Vector2(horizontal * moveSpeed, pctrl.rb.velocity.y);
    }

    public void OnPointDownRight()
    {
        horizontal = 1f;
        pctrl.rb.velocity = new Vector2(horizontal * moveSpeed, pctrl.rb.velocity.y);
    }


    public void Jump()
    {
        if (isControl)
        {
            if (IsGround())
            {
                pctrl.rb.velocity = new Vector2(pctrl.rb.velocity.x, jumpForce);
                EventManager.TurnOnAudio(SoundName.PLAYER_JUMP, false);
            }
            //if (pctrl.rb.velocity.y > 0f)
            //{
            //    pctrl.rb.velocity = new Vector2(pctrl.rb.velocity.x, pctrl.rb.velocity.y);
            //}
        }
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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void GetInputLaptop()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnPointDownLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnPointDownRight();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            OnPointUpLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            OnPointUpRight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isControl)
        {
            GetInputLaptop();
            UpdateSpriteFlip();
            UpdateAnimation();
        }
        //}
    }
    private void UpdateSpriteFlip()
    {
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
    }
    private void UpdateAnimation()
    {
        string newState = "";
        if (horizontal != 0f)
        {
            newState = MovementState.RUN;
        }
        else if (horizontal == 0)
        {
            newState = MovementState.IDLE;
        }
        if(rb.velocity.y > 0.5f)
        {
            newState = MovementState.JUMP;
        } 
        else if (rb.velocity.y < -0.5f)
        {
            newState = MovementState.FALL;
        }
        if(newState != state)
        {
            SetPlayerState(newState);
        }
    }
    public bool IsGround()
    {
        return Physics2D.BoxCast(col.bounds.min, new Vector2(col.bounds.size.x, 0.1f), 0, Vector2.down, 0, jumpableleGround);
    }

    private void SetPlayerState(string playerstate)
    {
        anim.Play(playerstate);
        state = playerstate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(Constrain.TAG_CHECKPOINTEND))
        {
            isControl = false;
            pctrl.rb.velocity = new Vector2(0, 0);
            pctrl.anim.Play(StatePlayer.RUN);
            state = StatePlayer.RUN;
            targetEndGame = collision.transform.GetComponent<CheckpointEnd>().targetEnd;
        }
        if (collision.transform.CompareTag(Constrain.TAG_ENDGAMEPOINT))
        {
            EventManager.EndGame?.Invoke(true);
        }
    }
}
