using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFin : MonoBehaviour
{
    [SerializeField]
    AudioClip musicEnd;
    [SerializeField]
    SfxProvider sfx;
    bool canInput = false;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return null;
        sfx.MusicEnd(musicEnd);
        yield return new WaitForSeconds(3f);
        canInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInput == true)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
