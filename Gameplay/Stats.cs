using UnityEngine;
using System;

public class Stats : MonoBehaviour
{
    [SerializeField] internal float _currentHealth = 0f;
    [SerializeField] internal float _startingHealth = 10f;
    [SerializeField] internal float _maxHealth = 10f;
    [SerializeField] internal float _baseDamage = 2f;
    [SerializeField] internal bool _isKO = false;
    public event Action<float> HealthChanged;
    protected event Action UnitKO;

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
    public void SubscribeOnUnitKO(Action value){
        UnitKO += value;
    }
}
