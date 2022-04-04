using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelSpawner : MonoBehaviour
{
    private Vector2 screen;

    [SerializeField] private GameObject fuelObject;
    [SerializeField] private float respawnTime = 1f;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(fuelWave());
    }

    void spawnRefuel()
    {
        GameObject obj = Instantiate(fuelObject);
        obj.transform.position = new Vector2(screen.x * 1.1f, Random.Range(screen.y - 18f, screen.y - 5f));
    }

    IEnumerator fuelWave()
    {
        while (true)
        {
            float respawnT = Random.Range(5f, 15f);
            yield return new WaitForSeconds(respawnT);
            spawnRefuel();
        }
    }
}
