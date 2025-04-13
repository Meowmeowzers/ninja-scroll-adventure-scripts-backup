using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] AttackType attackType;
   [SerializeField] Sprite weaponSprite;
   BoxCollider2D col;
   SpriteRenderer sr;
   Vector2 _direction;
   float _attackDamage = 1f;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		col = GetComponent<BoxCollider2D>();
      sr.enabled = false;
      col.enabled = false;

      if(weaponSprite != null){
         sr.sprite = weaponSprite;

         Vector2 size = sr.bounds.size;
         Vector2 pivotOffset = (Vector2)(weaponSprite.bounds.size / 2f) - (weaponSprite.pivot / weaponSprite.pixelsPerUnit);
         
         // Vector2 sizePPU = new Vector2(sr.sprite.rect.width / sr.sprite.pixelsPerUnit, sr.sprite.rect.height / sr.sprite.pixelsPerUnit);
         col.size = size;
         col.offset = pivotOffset;
      }
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
      attackType.InitializeWeapon(this);
   }

	public void Execute(Vector2 direction, GameObject source)
	{
      _direction = direction;
      if(attackType != null){ 
         attackType.Execute(this, source);
      }
	}

	public void ExitWeapon()
	{
	   attackType.ExitWeapon(this);
	}
	
   public Vector2 GetDirection(){
      return _direction;
   }

	internal float GetDamage(){
      return _attackDamage;
   }
}
