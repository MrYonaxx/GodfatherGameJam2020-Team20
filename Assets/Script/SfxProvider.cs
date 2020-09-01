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
    public void MusicBoss()
    {
        SoundManager.Instance.PlayMusic(Lib.bossMusic);
    }
    public void MusicBattel()
    {
        SoundManager.Instance.PlayMusic(Lib.battelMusic);
    }
    public void MusicDefense()
    {
        SoundManager.Instance.PlayMusic(Lib.defenseMusic);
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

    public void LevelUpJingle()
    {
        SoundManager.Instance.PlaySfX(Lib.levelUpJingle);
    }
    #endregion

    #region Enemies
    public void TakeDmgEnemyArcher()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemyArcher);
    }
    public void DieEnemyArcher()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemyArcher);
    }
    public void TakeDmgEnemyCaptain()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemyCaptain);
    }
    public void DieEnemyCaptain()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemyCaptain);
    }
    public void TakeDmgEnemyHealer()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemyHealer);
    }
    public void DieEnemyHealer()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemyHealer);
    }
    public void TakeDmgEnemyScout()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemyScout);
    }
    public void DieEnemyScout()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemyScout);
    }
    public void TakeDmgEnemyTank()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemyTank);
    }
    public void DieEnemyTank()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemyTank);
    }
    public void TakeDmgEnemy()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgEnemy);
    }
    public void DieEnemy()
    {
        SoundManager.Instance.PlaySfX(Lib.dieEnemy);
    }
    public void RunEnemy()
    {
        SoundManager.Instance.PlaySfX(Lib.runnerEnemy);
    }
    public void DamageEnemy()
    {
        SoundManager.Instance.PlaySfX(Lib.damageEnemy);
    }
    public void FireEnemy()
    {
        SoundManager.Instance.PlaySfX(Lib.fireEnemy);
    }
    public void TakeDmgHenchmen()
    {
        SoundManager.Instance.PlaySfX(Lib.takeDmgHenchmen);
    }
    public void DieHenchmen()
    {
        SoundManager.Instance.PlaySfX(Lib.dieHenchmen);
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
    public void BuyShop()
    {
        SoundManager.Instance.PlaySfX(Lib.buyShop);
    }
    public void MoneyEarned()
    {
        SoundManager.Instance.PlaySfX(Lib.moneyEarned);
    }
    public void WindowPopup()
    {
        SoundManager.Instance.PlaySfX(Lib.windowPopup);
    }

    #endregion

    #region Placement

    public void TrapPlacement()
    {
        SoundManager.Instance.PlaySfX(Lib.trapPlacement);
    }
    public void TroopPlacement()
    {
        SoundManager.Instance.PlaySfX(Lib.troopPlacement);
    }
    public void UnvalidZone()
    {
        SoundManager.Instance.PlaySfX(Lib.unvalidZone);
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

