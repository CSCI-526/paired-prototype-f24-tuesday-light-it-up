using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping;
    private Rigidbody2D rb;
    [HideInInspector] public bool isFacingRight = true;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Store the initial starting position
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
        if (Move > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (Move < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position = startPosition; // Move player back to start position
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
