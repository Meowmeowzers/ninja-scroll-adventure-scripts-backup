using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
   [SerializeField] List<AttackType> _attackType;
   Vector2 _direction;
   float _attackDamage = 1f;
   [SerializeField] int _currentAttackIndex = 0;

	void Awake()
	{
      _attackType[_currentAttackIndex].InitializeWeapon(this);
	}
   
	void OnTriggerEnter2D(Collider2D collision)
	{
      if(collision.GetComponent<IDamageable>() != null){
         collision.GetComponent<IDamageable>().DamageHealth(_attackDamage);
      }
	}

	public void StartWeapon(float attackDamage)
	{
      _attackDamage = attackDamage;
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

   public Vector2 GetDirection() => _direction;
   public int GetIndex() => _currentAttackIndex;
	internal float GetDamage() => _attackDamage;
}
