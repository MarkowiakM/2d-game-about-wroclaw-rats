using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimation;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction != 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(Mathf.Sign(direction) * 5f, 5f);
        }
        else
        {
            player.velocity = new Vector2(0f, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        UpdateAnimationParameters();
    }

    void UpdateAnimationParameters()
    {
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }
}
