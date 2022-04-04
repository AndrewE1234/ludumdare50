using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxFuel = 100;
    public float currentFuel;

    public FuelBar fuelBar;

    private float time = 0.0f;
    public float interpolatingPeriod = 10f;
    private bool isGameOver = false;


    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private float directionY = 0f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite upSprite;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, moveSpeed);
            spriteRenderer.sprite = upSprite;
        }

        if (Input.GetButtonUp("Jump"))
        {
            spriteRenderer.sprite = defaultSprite;
        }

        UpdateFuelStatus();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGameOver = true;
            print("game over");
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            AddFuel(10f);
            Destroy(collision.gameObject);
        }
    }

    void UpdateFuelStatus()
    {
        time += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentFuel > 0)
            {
                BurnFuel(0.02f);
            }
            else
            {
                // game over
                isGameOver = true;
                print("game over");
                SceneManager.LoadScene(0);
            }
        }
    }

    void BurnFuel(float burnFuel)
    {
        currentFuel -= burnFuel;
        fuelBar.SetFuel(currentFuel);
    }

    void AddFuel(float addFuel)
    {
        currentFuel += addFuel;

        if (currentFuel > 100)
        {
            currentFuel = 100;
        }

        fuelBar.SetFuel(currentFuel);
    }
}
