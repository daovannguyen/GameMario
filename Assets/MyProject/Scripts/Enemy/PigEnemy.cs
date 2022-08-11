using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PigEnemy : EnemyBase
{

    public float distaneDestroy = 0.2f;
    public override void Die()
    {
        gameObject.SetActive(false);
    }

    public override void Flip()
    {
        base.Flip();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterMap()
    {
        rb.velocity = new Vector2(curVelocity.x, 0);
        rb.gravityScale = 0;
    }

    public override void OnEnterPlayer(Collider2D collision)
    {
        bool ver = Mathf.Abs(collision.bounds.center.x - col.bounds.center.x) < distaneDestroy;
        bool hor = collision.bounds.center.y > col.bounds.center.y;
        if (ver && hor)
        {
            Die();
        }
        else
        {
            base.OnEnterPlayer(collision);
        }

    }

    public override void OnExitMap()
    {
        rb.gravityScale = 1;
    }

    protected override void Awake()
    {
        base.Awake();
        rb.velocity = curVelocity;
        rb.gravityScale = 1;
    }
    private bool IsGrounded()
    {
        float distance = (float) col.bounds.size.y / 10f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, col.bounds.size.y, groundLayer);
        return hit.collider != null;
    }
    private void Update()
    {
        if (IsGrounded())
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }
}



//public class PigEnemy : MonoBehaviour
//{
//    private Collider2D _collider;
//    private Rigidbody2D _rigidbody;
//    private Collider2D _colliderPlayer;
//    private float distanceDestroy = 0.2f;

//    [SerializeField]
//    private Transform moveLeft;
//    [SerializeField]
//    private Transform moveRight;

//    bool isRunLeft = true;
//    public float speed = -1f; // khởi tạo giá trị phải tương đương: isRunLeft = true thì speed = số ấm

//    private void Awake()
//    {
//        _rigidbody = GetComponent<Rigidbody2D>();

//        _collider = GetComponent<Collider2D>();
//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        _colliderPlayer = player.GetComponent<Collider2D>();
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.transform.CompareTag("Player"))
//        {

//            // xử lý nhảy bên trên thì Destroy
//            bool up = _collider.bounds.center.y < _colliderPlayer.bounds.center.y;
//            bool hor = Mathf.Abs(_collider.bounds.center.x - _colliderPlayer.bounds.center.x) <= distanceDestroy;
//            if (up && hor)
//            {
//                _rigidbody.AddForce(new Vector2(0, 100));
//                Destroy(gameObject);
//                return;
//            }
//        }
//        else if (collision.transform.CompareTag("Flip"))
//        {
//            isRunLeft = !isRunLeft;
//            Flip();
//        }
//    }


//    void Flip()
//    {

//        // xoay ngược
//        Vector3 localScale = transform.localScale;
//        if (isRunLeft)
//        {
//            localScale.x = 1;
//        }
//        else
//        {
//            localScale.x = -1;
//        }
//        transform.localScale = localScale;
//    }
//    private void MoveAround()
//    {

//    }
//    private void Update()
//    {
//        SetRun();
//    }
//    private void SetRun()
//    {

//        // gia tốc ngược
//        var curSpeed = speed * (isRunLeft ? -1 : 1);
//        _rigidbody.velocity = new Vector2(curSpeed * Time.deltaTime, 0);
//    }
//}
