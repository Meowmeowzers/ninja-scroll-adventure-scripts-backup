using UnityEngine;

[CreateAssetMenu(menuName="Attacks/BasicProjectile")]
public class RangedAttack : AttackType
{
	[SerializeField] GameObject _projectileSprite;
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] AudioClip _weaponSound;
	float _angle;
	
	public override void InitializeWeapon(Weapon weapon)
	{
		if(_weaponSprite != null){
			SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
			BoxCollider2D col = weapon.GetComponent<BoxCollider2D>();

			sr.sprite = _weaponSprite;
			
			Vector2 size = sr.bounds.size;
			Vector2 pivotOffset = (Vector2)(_weaponSprite.bounds.size / 2f) - (_weaponSprite.pivot / _weaponSprite.pixelsPerUnit);
			
			// Vector2 sizePPU = new Vector2(sr.sprite.rect.width / sr.sprite.pixelsPerUnit, sr.sprite.rect.height / sr.sprite.pixelsPerUnit);
			col.size = size;
			col.offset = pivotOffset;
		}
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}

	public override void StartWeapon(Weapon weapon){
		if(_weaponSound != null)
			GameManager.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){
	
	}

    public override void Execute(Weapon weapon, GameObject source){
		GameObject projectile = Instantiate(_projectileSprite, weapon.transform.position, Quaternion.identity);

		_angle = Mathf.Atan2(weapon.GetDirection().y, weapon.GetDirection().x) * Mathf.Rad2Deg;

		projectile.transform.rotation = Quaternion.Euler(0f, 0f, _angle - 90f);
		projectile.GetComponent<Projectile>().Fire(weapon, source);
	}
}
