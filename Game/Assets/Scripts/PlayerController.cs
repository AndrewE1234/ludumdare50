using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private CapsuleCollider2D capsuleCollider2D;

    private float directionX = 0f;
    private float moveSpeed = 7f;
    private float jumpForce = 14f;

    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(directionX * moveSpeed, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.CompareTag("Ground"));
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
