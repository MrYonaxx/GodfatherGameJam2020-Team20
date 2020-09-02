using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundLibrary : ScriptableObject
{
    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip baseMusic;
    public AudioClip genericMusic;
    public AudioClip selectorMusic;

    [Header("Jingle")]
    public AudioClip victoryJingle;
    public AudioClip defeatJingle;

    [Header("Menu")]
    public AudioClip selectButton;
    public AudioClip windowPopup; 
    public AudioClip validateButton; 
    public AudioClip cancelButton;

}