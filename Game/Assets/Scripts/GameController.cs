using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static float score = 0f;

    private bool showMenu = true;
    private bool showHeader = false;
    private bool gameActive = false;
    private float currentTime;

    [SerializeField] private float moveSpeed = -5f;
    [SerializeField] private Text highScoreUI;
    [SerializeField] private Text timerUI;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //print("High Score: " + GameController.score);

        if (Input.GetButton("Submit") && !gameActive)
        {
            GameStart();
        }
        if (Input.GetButton("Cancel") && !gameActive)
        {
            Application.Quit();
        }

        currentTime += Time.deltaTime;

        if (currentTime > GameController.score)
        {
            GameController.score = currentTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerUI.text = time.ToString(@"mm\:ss");

        TimeSpan highScoreTime = TimeSpan.FromSeconds(GameController.score);
        highScoreUI.text = highScoreTime.ToString(@"mm\:ss");
    }


    public void GameStart()
    {
        gameActive = true;
        panel.SetActive(false);
        header.SetActive(true);
        Time.timeScale = 1f;
    }
}
