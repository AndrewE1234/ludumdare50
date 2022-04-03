using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;

    private float directionX = 0f;
    private float directionY = 0f;
    [SerializeField] private float moveSpeed = 5f;
    private float jumpForce = 14f;

    private bool isJumping = false;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, moveSpeed);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
