using Rewired.Utils.Platforms.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Control;
    public GameObject Main_Menu;

    public void OnStart()
    {
        SceneManager.LoadScene("Lvl 1");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnControlOpen()
    {
        Control.SetActive(true);
        Main_Menu.SetActive(false);
    }

    public void OnControlClose()
    {
        Control.SetActive(false);
        Main_Menu.SetActive(true);
    }
}
