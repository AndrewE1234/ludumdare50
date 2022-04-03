using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    private int currentHealth = 3;
    private int numOfTotalHearts = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private float time = 0.0f;
    public float interpolatingPeriod = 5f;
    private bool isGameOver = false;

    void Update()
    {
        time += Time.deltaTime;

        if (!isGameOver && time >= interpolatingPeriod)
        {
            time = 0.0f;
            if (currentHealth > 0)
            {
                currentHealth--;
            }

            if (currentHealth == 0)
            {
                // game over
                isGameOver = true;
                print("game over");
                SceneManager.LoadScene(0);
            }
        }


        if (currentHealth > numOfTotalHearts)
        {
            currentHealth = numOfTotalHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            } 
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfTotalHearts)
            {
                hearts[i].enabled = true;
            } 
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
