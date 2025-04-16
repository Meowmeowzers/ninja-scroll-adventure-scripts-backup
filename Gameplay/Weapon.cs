using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] AttackType _attackType;
   Vector2 _direction;
   float _attackDamage = 1f;

	void Awake()
	{
      _attackType.InitializeWeapon(this);
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
      _attackType.StartWeapon(this);
   }

	public void Execute(Vector2 direction, GameObject source)
	{
      _direction = direction;
      if(_attackType != null){ 
         _attackType.Execute(this, source);
      }
	}

	public void ExitWeapon()
	{
	   _attackType.ExitWeapon(this);
	}
	
   public Vector2 GetDirection(){
      return _direction;
   }

	internal float GetDamage(){
      return _attackDamage;
   }
}
