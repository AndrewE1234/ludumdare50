using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour
{
    public Text timerUI;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isGameOver)
        //{
        currentTime += Time.deltaTime;
        //}

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerUI.text = time.ToString(@"mm\:ss");
    }
}
