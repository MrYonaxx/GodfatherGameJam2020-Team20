using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundLibrary : ScriptableObject
{
    [Header("Le Carré")]
    public AudioClip walkSquare;
    public AudioClip returnSquare;
    public AudioClip smashSquare;
    public AudioClip speakSquare;
    public AudioClip victorySquare;

    [Header("Le triangle")]
    public AudioClip walkTriangle;
    public AudioClip returnTriangle;
    public AudioClip horizontalTriangle;
    public AudioClip pasteTriangle;
    public AudioClip swapHorizontalTriangle;
    public AudioClip victoryTriangle;

    [Header("Demi-Lune")]
    public AudioClip walkHalfMoon;
    public AudioClip returnHalfMoon;
    public AudioClip rowboatMode;
    public AudioClip pushRowboatMode;
    public AudioClip waterRowboatMode;
    public AudioClip victoryHalfMoon;

    [Header("Music & Jingle")]
    public AudioClip musicMenu;
    public AudioClip musicInGame;
    public AudioClip victoryJingle;

    [Header("Environnements")]
    public AudioClip destructionWall;
    public AudioClip fallInWater; 
    public AudioClip randomSFX;

    [Header("Feedbacks UI")]
    public AudioClip buttonOver;
    public AudioClip buttonSelector;
    public AudioClip tutoSFX;
}