using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProvider : MonoBehaviour
{

    public enum Musics
    {
        Menu,
        Generic,
        Boss
    }

    public SoundLibrary Lib;
    public Musics Choice;

    // Use this for initialization
    void Start()
    {
        switch (Choice)
        {
            case Musics.Menu:
                SoundManager.Instance.PlayMusic(Lib.menuMusic);
                break;
            case Musics.Generic:
                SoundManager.Instance.PlayMusic(Lib.genericMusic);
                break;
            
        }
    }
}