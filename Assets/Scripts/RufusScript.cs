using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RufusScript : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 7f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LevelManager lm;
    private bool isTouchingGround;

    private Animator playerAnimation;
    private GameStateManager GameStateManager;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if(!lm.isRufusDead)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal 2");

            if (direction != 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(Mathf.Sign(direction) * 5f, 5f);
            }
            else
            {
                player.velocity = new Vector2(0f, player.velocity.y);
            }

            if (Input.GetButtonDown("Jump 2") && isTouchingGround)
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
        if (!lm.isRufusDead)
        {
            if (other.gameObject.CompareTag("RufusCheese"))
            {
                GameStateManager.PlaySFX("cheeseBite");
                Destroy(other.gameObject);
                lm.rufusCoins++;
            }
            if (other.gameObject.CompareTag("RubyWater") || other.gameObject.CompareTag("Enemy"))
            {
                GameStateManager.PlaySFX("gameOver");
                playerAnimation.SetTrigger("Death");
                lm.isRufusDead = true;
            }
        }
    }
}
