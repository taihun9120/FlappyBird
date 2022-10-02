using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 200.0f;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isDead)
        {
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
            GameManager.instance.isDead = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            GameManager.instance.addScore();
            GameManager.instance.addSpeed();
        }
    }
}
