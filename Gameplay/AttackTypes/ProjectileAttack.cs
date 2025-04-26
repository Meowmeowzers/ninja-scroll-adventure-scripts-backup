using UnityEngine;

[CreateAssetMenu(menuName="Attacks/BasicProjectile")]
public class ProjectileAttack : AttackType
{
	[SerializeField] GameObject _projectile;
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] float _damage = 1f;
	[SerializeField] AudioClip _weaponSound;
	
	public override void InitializeWeapon(Weapon weapon)
	{
		if(_weaponSprite != null){
			SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
			BoxCollider2D col = weapon.GetComponent<BoxCollider2D>();

			sr.sprite = _weaponSprite;
			col.size = sr.bounds.size;
			col.offset = (Vector2)(_weaponSprite.bounds.size / 2f) - (_weaponSprite.pivot / _weaponSprite.pixelsPerUnit);
		}
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}

	public override void StartWeapon(Weapon weapon){
		if(_weaponSound != null)
			GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){
	
	}

    public override void Execute(Weapon weapon, GameObject source){
		GameObject projectile = Instantiate(_projectile, weapon.transform.position, Quaternion.identity);

		projectile.GetComponent<Projectile>().Fire(weapon, source);
	}

	public override float GetDamage() => _damage;
}
