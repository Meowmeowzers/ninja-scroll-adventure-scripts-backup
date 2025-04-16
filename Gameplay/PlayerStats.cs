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
    public void DamageHealth(float amount){
        if(_isKO) return;

        _currentHealth -= amount;
        OnUnitDamaged();       
        UpdateHealth();
        if(_currentHealth < 1f){
            _isKO = true;
            if(_KOSound != null) GameManager.PlaySound(_KOSound);
            OnUnitIsKO();
        }
    }
}
