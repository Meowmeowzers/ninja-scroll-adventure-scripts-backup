public class PlayerStats : Stats, IDamageable
{
	void Awake()
	{
        _currentHealth = _startingHealth;
        if(_startingHealth > _maxHealth) _currentHealth = _maxHealth;
	}

    public void RestoreHealth(float amount){
        if(_isKO) return;

        _currentHealth += amount;

        if(_currentHealth > _maxHealth){
            _currentHealth = _maxHealth;
        }
        // HealthChanged += RestoreHealth;
        // HealthChanged?.Invoke(currentHealth);
    }
    public void DamageHealth(float amount){
        if(_isKO) return;

        _currentHealth -= amount;

        if(_currentHealth < 1f){
            _isKO = true;
            OnUnitIsKO();
        }
        // HealthChanged?.Invoke(currentHealth);
    }


}
