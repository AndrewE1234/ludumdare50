using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool showMenu = true;
    private bool showHeader = false;
    private bool gameActive = false;

    [SerializeField] private GameObject header;
    [SerializeField] private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit") && !gameActive)
        {
            GameStart();
        }
        if (Input.GetButton("Cancel") && !gameActive)
        {

        }
    }

    

    public void GameStart()
    {
        gameActive = true;
        panel.SetActive(false);
        header.SetActive(true);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
