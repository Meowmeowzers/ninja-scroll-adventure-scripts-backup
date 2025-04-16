using UnityEngine;
using System;
using System.Collections;

public class Stats : MonoBehaviour
{
    [SerializeField] internal float _currentHealth = 0f;
    [SerializeField] internal float _startingHealth = 10f;
    [SerializeField] internal float _maxHealth = 10f;
    [SerializeField] internal bool _isKO = false;
    public event Action<float> OnHealthChanged;
    public event Action UnitKO;
    public event Action UnitDamaged;

	void Awake()
	{
        _currentHealth = _startingHealth;
        if(_startingHealth > _maxHealth) _currentHealth = _maxHealth;
	}

    public float GetHealth(){
        return _currentHealth;
    }

    protected void OnUnitIsKO(){
        UnitKO?.Invoke();
    }
    protected void OnUnitDamaged(){
        UnitDamaged?.Invoke();
    }
    public IEnumerator TakeHitEffect(){
        yield return new WaitForSeconds(0.1f);
    }
    public void UpdateHealth(){
        OnHealthChanged?.Invoke(_currentHealth);
    }
}
