using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float maxFuel = 100;
    public float currentFuel;

    public FuelBar fuelBar;

    private float time = 0.0f;
    public float interpolatingPeriod = 10f;
    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (!isGameOver && time >= interpolatingPeriod)
        {
            time = 0.0f;

            if (currentFuel < 100)
            {
                AddFuel(10);
            }
        }


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
