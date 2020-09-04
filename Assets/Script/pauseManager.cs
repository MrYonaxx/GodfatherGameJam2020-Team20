using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour
{
    private bool isPauseActivated;
    public Selectable ControlDefautFocus;
    public Selectable Main_MenuDefautFocus;
    public GameObject canvasPause, pauseMain, pauseControl;
    bool IncontrolMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        isPauseActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isPauseActivated || Input.GetButtonDown("Start") && !isPauseActivated)
        {
            canvasPause.SetActive(true);
            isPauseActivated = true;
        }
        if (IncontrolMenu == true)
        {
            if (Input.GetButtonDown("Fire2"))
                BackInPause();
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
        IncontrolMenu = true;
    }

    public void ReturnInMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackInPause()
    {
        pauseMain.SetActive(true);
        pauseControl.SetActive(false);
        IncontrolMenu = false;
    }
}
