using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float jumpPower;
    private Rigidbody2D player;
    private int jumpCounter;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [HideInInspector] public bool isFacingRight;
    [SerializeField] private Transform startPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        jumpCounter = 0;
        isFacingRight = true;
        player = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player's facing direction
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            isFacingRight = true;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            isFacingRight = false;
        }

        //Wall jump
        if (wallJumpCooldown < 0.2f)
        {

            player.velocity = new Vector2(speed * horizontalInput, player.velocity.y);

            if (onWall() && !isGrounded())
            {
                player.gravityScale = 0;
                player.velocity = Vector2.zero;
            }
            else
                player.gravityScale = 1;

            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.J)) && jumpCounter != 1)
            {
                jumpCounter++;
                if (isGrounded())
                {
                    jumpCounter = 0;
                    player.velocity = new Vector2(player.velocity.x, jumpPower);
                }
                else if (onWall() && !isGrounded())
                {
                    if (horizontalInput == 0)
                    {
                        player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                        transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    }
                    else
                        player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

                    wallJumpCooldown = 0;
                }
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = startPosition.position; // Move player back to start position
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
