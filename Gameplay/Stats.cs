using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{
    [SerializeField] protected float _currentHealth = 0f;
    [SerializeField] protected float _startingHealth = 10f;
    [SerializeField] protected float _maxHealth = 10f;
    [SerializeField] protected List<DamageType> _damageTypeImmunities;
    [SerializeField] protected bool _isKO = false;
    public event Action<float> OnHealthChanged;
    public event Action OnUnitKO;
    public event Action OnUnitDamaged;

	void Awake()
	{
        _currentHealth = _startingHealth;
        if(_startingHealth > _maxHealth) _currentHealth = _maxHealth;
	}

    public float GetHealth(){
        return _currentHealth;
    }

    protected void UnitKO(){
        OnUnitKO?.Invoke();
    }
    protected void UnitDamaged(){
        OnUnitDamaged?.Invoke();
    }
    public IEnumerator TakeHitEffect(){
        yield return new WaitForSeconds(0.1f);
    }
    public void UpdateHealth(){
        OnHealthChanged?.Invoke(_currentHealth / _maxHealth);
    }
}
