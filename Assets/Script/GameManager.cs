using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool musicMute;
    public bool sfxMute;

    void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }
    public void LoadScene(string toLoad)
    {

        SceneManager.LoadScene(toLoad);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
