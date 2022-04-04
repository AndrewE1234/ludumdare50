using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class TimerController : MonoBehaviour
{
    public Text timerUI;
    [SerializeField] private Text highScoreUI;
    private float currentTime;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
}
