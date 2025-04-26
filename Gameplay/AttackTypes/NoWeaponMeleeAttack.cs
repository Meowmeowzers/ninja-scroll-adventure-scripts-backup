using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/NoWeaponMelee")]
public class NoWeaponMeleeAttack : AttackType
{
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] float _damage = 1f;
	[SerializeField] List<DamageType> _damageType = new(){DamageType.MeleePhysical};
	[SerializeField] AudioClip _weaponSound;
	[SerializeField] Vector2 _initialLocationOffset = Vector2.zero;
	[SerializeField] float _offsetDistance = 0.8f;
    [SerializeField] GameObject _particleEffect;
										
	Vector2 _offset;
	float _angle;

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
      	weapon.GetComponent<BoxCollider2D>().enabled = true;
		if(_weaponSound != null)
			GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}
	public override void Execute(Weapon weapon, GameObject source){		
		_angle = Mathf.Atan2(weapon.GetDirection().y, weapon.GetDirection().x) * Mathf.Rad2Deg;
		_offset = Quaternion.Euler(0, 0, _angle) * Vector2.right * _offsetDistance;
		weapon.transform.SetLocalPositionAndRotation(_offset + _initialLocationOffset, Quaternion.Euler(0f, 0f, _angle - 90f));
        Instantiate(_particleEffect, (Vector2) source.transform.position, Quaternion.identity);
	}

	public override float GetDamage() => _damage;
	public override List<DamageType> GetDamageType() => _damageType;
}
