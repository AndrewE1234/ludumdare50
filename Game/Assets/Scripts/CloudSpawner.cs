using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    private Vector2 screen;
    private SpriteRenderer cloudSpriteRenderer;

    [SerializeField] private GameObject cloudObject;
    [SerializeField] private float respawnTime = 1f;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(cloudWave());
    }

    void spawnCloud()
    {
        cloudSpriteRenderer = cloudObject.GetComponent<SpriteRenderer>();
        cloudSpriteRenderer.sprite = sprites[Random.Range(0, sprites.Length - 1)];

        GameObject obj = Instantiate(cloudObject);
        obj.transform.position = new Vector2(screen.x * 1.1f, Random.Range(screen.y - 6f, screen.y - 0.5f));
    }

    IEnumerator cloudWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCloud();
        }
    }
}
