using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 1f;
    
    private Rigidbody2D rb2d;
    private bool isGrounded;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = gravityScale;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }
    // public float speed = 5f;
    // public float jumpForce = 10f;
    // private Rigidbody2D rb;
    // private bool isGrounded;
    


    // void Start()
    // {
    //     rb = GetComponent<Rigidbody2D>();

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //     {
    //         rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //         isGrounded = false;
    //     }
    // }
    // void FixedUpdate()
    // {
    //     float moveHorizontal = Input.GetAxis("Horizontal");
    //     float moveVertical = Input.GetAxis("Vertical");

    //     Vector2 movement = new Vector2(moveHorizontal, moveVertical);
    //     rb.velocity= movement * speed;
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("platform"))
    //     {
    //         isGrounded = true;
    //     }
    // }
}
