using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Hit");
            spriteRenderer.color = new Color(149f, 38f, 6f);
        }
    }
}
