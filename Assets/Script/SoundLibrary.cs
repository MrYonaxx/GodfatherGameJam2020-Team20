using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundLibrary : ScriptableObject
{
    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip baseMusic;
    public AudioClip battelMusic;
    public AudioClip defenseMusic;
    public AudioClip bossMusic;
    public AudioClip genericMusic;
    public AudioClip selectorMusic;

    [Header("Jingle")]
    public AudioClip victoryJingle;
    public AudioClip defeatJingle;
    public AudioClip levelUpJingle;

    [Header("Enemy")]
    public AudioClip takeDmgEnemyArcher;
    public AudioClip dieEnemyArcher;
    public AudioClip takeDmgEnemyCaptain;
    public AudioClip dieEnemyCaptain;
    public AudioClip takeDmgEnemyHealer;
    public AudioClip dieEnemyHealer;
    public AudioClip takeDmgEnemyScout;
    public AudioClip dieEnemyScout;
    public AudioClip takeDmgEnemyTank;
    public AudioClip dieEnemyTank;
    public AudioClip fireEnemy;
    public AudioClip dieEnemy;
    public AudioClip damageEnemy;
    public AudioClip takeDmgEnemy;
    public AudioClip runnerEnemy;
    public AudioClip takeDmgHenchmen;
    public AudioClip dieHenchmen;

    [Header("Shop")]
    public AudioClip buyShop;
    public AudioClip moneyEarned; 

    [Header("Menu")]
    public AudioClip selectButton;
    public AudioClip windowPopup; 
    public AudioClip validateButton; 
    public AudioClip cancelButton;

    [Header("Placement")]
    public AudioClip trapPlacement;
    public AudioClip troopPlacement;
    public AudioClip unvalidZone;
}