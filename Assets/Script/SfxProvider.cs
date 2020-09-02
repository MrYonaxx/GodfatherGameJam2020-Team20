using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A mettre sur GameObject pour faire du song
public class SfxProvider : MonoBehaviour
{
    public SoundLibrary Lib;

    #region Music
    public void MusicMenu()
    {
        SoundManager.Instance.PlayMusic(Lib.menuMusic);
    }
    public void MusicGeneric()
    {
        SoundManager.Instance.PlayMusic(Lib.genericMusic);
    }
   
    public void MusicBase()
    {
        SoundManager.Instance.PlayMusic(Lib.baseMusic);
    }
    public void MusicSelector()
    {
        SoundManager.Instance.PlayMusic(Lib.selectorMusic);
    }
    #endregion

    #region Jingles
    public void VictoryJingle()
    {
        SoundManager.Instance.PlaySfX(Lib.victoryJingle);
    }
    public void DefeatJingle()
    {
        SoundManager.Instance.PlaySfX(Lib.defeatJingle);
    }

    
    #endregion

    #region UI
    public void SelectButton()
    {
        SoundManager.Instance.PlaySfX(Lib.selectButton);
    }
    public void ValidateButton()
    {
        SoundManager.Instance.PlaySfX(Lib.validateButton);
    }
    public void CancelButton()
    {
        SoundManager.Instance.PlaySfX(Lib.cancelButton);
    }
 
    public void WindowPopup()
    {
        SoundManager.Instance.PlaySfX(Lib.windowPopup);
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

