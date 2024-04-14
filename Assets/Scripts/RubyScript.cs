using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 7f;
    private float direction = 0f;
    private Rigidbody2D player;
    public bool isDead = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public CoinManager cm;
    private bool isTouchingGround;

    private Animator playerAnimation;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if(!isDead)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal 1");

            if (direction != 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(Mathf.Sign(direction) * 5f, 5f);
            }
            else
            {
                player.velocity = new Vector2(0f, player.velocity.y);
            }

            if (Input.GetButtonDown("Jump 1") && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }

            UpdateAnimationParameters();
        }
    }

    void UpdateAnimationParameters()
    {
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag("RubbyCheese"))
            {
                Destroy(other.gameObject);
                cm.coinCount++;
            }
            if (other.gameObject.CompareTag("RufusWater"))
            {
                playerAnimation.SetTrigger("Death");
                isDead = true;
            }
        }
    }
}
