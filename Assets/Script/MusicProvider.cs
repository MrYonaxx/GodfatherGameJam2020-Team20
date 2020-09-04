using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProvider : MonoBehaviour
{

    public enum Musics
    {
        Menu,
        Game
    }

    public SoundLibrary Lib;
    public Musics Choice;

    // Use this for initialization


    void Start()
    {
        switch (Choice)
        {
            case Musics.Menu:
                SoundManager.Instance.PlayMusic(Lib.musicMenu);
                break;
            case Musics.Game:
                SoundManager.Instance.PlayMusic(Lib.musicInGame);
                break;
            
        }
    }
}