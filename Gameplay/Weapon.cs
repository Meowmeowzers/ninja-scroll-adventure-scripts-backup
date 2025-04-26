using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
   [SerializeField] List<AttackType> _attackType;
   Vector2 _direction;
   [SerializeField] int _currentAttackIndex = 0;
   float _weaponDamage = 0;
   List<DamageType> _damageType;

	void Awake()
	{
      _attackType[_currentAttackIndex].InitializeWeapon(this);
	}
   
	void OnTriggerEnter2D(Collider2D collision)
	{
      collision.GetComponent<IDamageable>()?.DamageHealth(_weaponDamage, _damageType);
	}

	public void StartWeapon(float attackStat)
	{
      _weaponDamage = attackStat + _attackType[_currentAttackIndex].GetDamage();
      _damageType = _attackType[_currentAttackIndex].GetDamageType();
      _attackType[_currentAttackIndex].StartWeapon(this);
   }

	public void Execute(Vector2 direction, GameObject source)
	{
      _direction = direction;
      if(_attackType[_currentAttackIndex] != null){ 
         _attackType[_currentAttackIndex].Execute(this, source);
      }
	}

	public void ExitWeapon()
	{
	   _attackType[_currentAttackIndex].ExitWeapon(this);
	}
	
   public void SwitchWeapon(int index){
      if(_attackType[_currentAttackIndex] != null){
         _attackType[_currentAttackIndex].ExitWeapon(this);
      }
      _currentAttackIndex = index;
      _attackType[_currentAttackIndex].InitializeWeapon(this);
   }
   
   public void NextAttack(){
      _currentAttackIndex++;
      if(_currentAttackIndex >= _attackType.Count && _attackType.Count != 0){
         _currentAttackIndex = 0;
      }
   }
   public void PrevAttack(){
      _currentAttackIndex--;
      if(_currentAttackIndex < 0 && _attackType.Count != 0){
         _currentAttackIndex = _attackType.Count - 1;
      }
   }

   public Vector2 GetDirection() => _direction;
   public int GetIndex() => _currentAttackIndex;

	public float GetDamage() => _weaponDamage;
}
