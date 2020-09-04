﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    private bool isPauseActivated;

    public GameObject canvasPause, pauseMain, pauseControl;

    // Start is called before the first frame update
    void Start()
    {
        isPauseActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isPauseActivated)
        {
            canvasPause.SetActive(true);
            isPauseActivated = true;
        }
    }

    public void ReturnInGame()
    {
        pauseControl.SetActive(false);
        pauseMain.SetActive(true);
        canvasPause.SetActive(false);
        isPauseActivated = false;
    }

    public void DisplayControl()
    {
        pauseMain.SetActive(false);
        pauseControl.SetActive(true);
    }

    public void ReturnInMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackInPause()
    {
        pauseMain.SetActive(true);
        pauseControl.SetActive(false);
    }
}