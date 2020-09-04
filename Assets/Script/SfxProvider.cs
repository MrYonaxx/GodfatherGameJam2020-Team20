using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A mettre sur GameObject pour faire du song
public class SfxProvider : MonoBehaviour
{
    public SoundLibrary Lib;

    #region Le Carré
    public void WalkSquare()
    {
        SoundManager.Instance.PlaySfX(Lib.walkSquare);
    }
    public void ReturnSquare()
    {
        SoundManager.Instance.PlaySfX(Lib.returnSquare);
    }
   
    public void SmashSquare()
    {
        SoundManager.Instance.PlaySfX(Lib.smashSquare);
    }
    public void SpeakSquare()
    {
        SoundManager.Instance.PlaySfX(Lib.speakSquare);
    }
    public void VictorySquare()
    {
        SoundManager.Instance.PlaySfX(Lib.victorySquare);
    }
    #endregion

    #region Le triangle
    public void WalkTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.walkTriangle);
    }
    public void ReturnTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.returnTriangle);
    }
    public void HorizontalTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.horizontalTriangle);
    }
    public void PasteTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.pasteTriangle);
    }
    public void SwapHorizontalTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.swapHorizontalTriangle);
    }
    public void VictoryTriangle()
    {
        SoundManager.Instance.PlaySfX(Lib.victoryTriangle);
    }
    #endregion

    #region Demi-Lune
    public void WalkHalfMoon()
    {
        SoundManager.Instance.PlaySfX(Lib.walkHalfMoon);
    }
    public void ReturnHalfMoon()
    {
        SoundManager.Instance.PlaySfX(Lib.returnHalfMoon);
    }
    public void rowboatMode()
    {
        SoundManager.Instance.PlaySfX(Lib.rowboatMode);
    }
    public void pushRowboatMode()
    {
        SoundManager.Instance.PlaySfX(Lib.pushRowboatMode);
    }
    public void waterRowboatMode()
    {
        SoundManager.Instance.PlaySfX(Lib.waterRowboatMode);
    }
    public void victoryHalfMoon()
    {
        SoundManager.Instance.PlaySfX(Lib.victoryHalfMoon);
    }
    #endregion

    #region Music & Jingle
    public void MusicMenu()
    {
        SoundManager.Instance.PlayMusic(Lib.musicMenu);
    }
    public void MusicInGame()
    {
        SoundManager.Instance.PlayMusic(Lib.musicInGame);
    }
    public void MusicEnd(AudioClip audio)
    {
        SoundManager.Instance.PlayMusic(audio);
    }
    public void VictoryJingle()
    {
        SoundManager.Instance.PlaySfX(Lib.victoryJingle);
    }
    #endregion

    #region Environnements
    public void DestructionWall()
    {
        SoundManager.Instance.PlaySfX(Lib.destructionWall);
    }
    public void FallInWater()
    {
        SoundManager.Instance.PlaySfX(Lib.fallInWater);
    }
    public void RandomSFX()
    {
        SoundManager.Instance.PlaySfX(Lib.randomSFX);
    }
    #endregion

    #region Feedbacks UI
    public void ButtonOver()
    {
        SoundManager.Instance.PlaySfX(Lib.buttonOver);
    }
    public void ButtonSelector()
    {
        SoundManager.Instance.PlaySfX(Lib.buttonSelector);
    }
    public void TutoSFX()
    {
        SoundManager.Instance.PlaySfX(Lib.tutoSFX);
    }
    #endregion

    private List<string> _currentPlay = new List<string>();
    public void PlayFx(AudioClip sound)
    {
        StartCoroutine(PlaySound(sound));
    }

    private IEnumerator PlaySound(AudioClip sound)
    {
        if (_currentPlay.Contains(sound.name))
        {
            yield break;
        }
        SoundManager.Instance.PlaySfX(sound);
        _currentPlay.Add(sound.name);
        yield return new WaitForSeconds(1f);
        _currentPlay.Remove(sound.name);
    }
}

