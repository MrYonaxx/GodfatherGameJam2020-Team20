using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    // public Animator transitionAnim;
    // public Animator transitionAnimBar;

    public float transitionTime = 1f;

    public void LoadNextLevel(string i)
    {
        StartCoroutine(LoadLevel(i));
    }

    IEnumerator LoadLevel(string i)
    {
        //Play animation
        transition.SetTrigger("Start");
        // transitionAnim.SetTrigger("Start");
        // transitionAnimBar.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load scene

        SceneManager.LoadScene(i);
    }
}
