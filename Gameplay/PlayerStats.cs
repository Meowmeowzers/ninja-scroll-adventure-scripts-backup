using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats, IDamageable
{  
    [SerializeField] AudioClip _KOSound;

    public void RestoreHealth(float amount){
        if(_isKO) return;

        _currentHealth += amount;

        if(_currentHealth > _maxHealth){
            _currentHealth = _maxHealth;
        }
        UpdateHealth();
    }
    public void DamageHealth(float amount, List<DamageType> damageType){
        if(_isKO) return;
        foreach(var i in damageType){
            if(_damageTypeImmunities.Contains(i)) return;
        }

        _currentHealth -= amount;
        UnitDamaged();       
        UpdateHealth();
        if(_currentHealth < 1f){
            _isKO = true;
            if(_KOSound != null) GameManager.instance.audioPlayer.PlaySound(_KOSound);
            UnitKO();
            GameManager.instance.GameOver();
        }
    }
}
