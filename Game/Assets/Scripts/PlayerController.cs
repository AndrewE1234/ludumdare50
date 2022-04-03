using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private float directionY = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.GetAxisRaw("Vertical");
        if (Input.GetButton("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, moveSpeed);
        }
    }
}
