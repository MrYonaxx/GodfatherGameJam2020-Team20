﻿using Rewired.Utils.Platforms.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Control;
    public GameObject Main_Menu;
    public Selectable ControlDefautFocus;
    public Selectable Main_MenuDefautFocus;

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
        EventSystem.current.SetSelectedGameObject(ControlDefautFocus.gameObject);
    }

    public void OnControlClose()
    {
        Control.SetActive(false);
        Main_Menu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(Main_MenuDefautFocus.gameObject);
    }
}
