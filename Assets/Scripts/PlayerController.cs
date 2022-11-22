using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Color { BLUE, GREEN, ORANGE, PINK, YELLOW };
    public float jumpForce = 200.0f;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsDead)
        {
            animator.speed = 0.0f;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetButton("Jump"))
        {
            playerRigidbody.gravityScale = 0;
        }
        if (Input.GetButtonUp("Jump"))
        {
            playerRigidbody.gravityScale = 1.2f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Dead")
        {
            GameManager.instance.IsDead = true;
            GameManager.instance.Die();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            GameManager.instance.AddScore();
            GameManager.instance.AddSpeed();
        }
    }

    public void SetColor(Color color)
    {
        animator.SetInteger("color", (int)color);
    }
}
