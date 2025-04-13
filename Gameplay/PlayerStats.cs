public class PlayerStats : Stats, IDamageable
{
    public void RestoreHealth(float amount){
        if(_isKO) return;

        _currentHealth += amount;

        if(_currentHealth > _maxHealth){
            _currentHealth = _maxHealth;
        }
    }
    public void DamageHealth(float amount){
        if(_isKO) return;

        _currentHealth -= amount;
        OnUnitDamaged();       
        if(_currentHealth < 1f){
            _isKO = true;
            OnUnitIsKO();
        }
    }
}
