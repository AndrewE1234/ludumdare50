using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed = -5f;
    private Vector2 screen;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(moveSpeed, 0);
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        // Delete cloud when it leaves the camera view
        if (transform.position.x < screen.x * -1.1)
        {
            print("Ima delete");
            Destroy(this.gameObject);
        }
    }
}
