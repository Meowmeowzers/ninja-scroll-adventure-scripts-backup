using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/KamikazeAttack")]
public class KamikazeAttackAttack : AttackType
{
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _damage = 2f;
    [SerializeField] List<DamageType> _damageType;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] AudioClip _weaponSound;
	
	public override void InitializeWeapon(Weapon weapon){
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

	public override void ExitWeapon(Weapon weapon){}

    public override void Execute(Weapon weapon, GameObject source){
        
        if (_explosionEffect != null)
            Instantiate(_explosionEffect, source.transform.position, Quaternion.identity);

        Collider2D[] hits = Physics2D.OverlapCircleAll(source.transform.position, _explosionRadius);
        foreach (Collider2D hit in hits)
            hit.GetComponent<IDamageable>()?.DamageHealth(_damage, _damageType);
        
        source.GetComponent<IDamageable>().DamageHealth(_damage * 10, _damageType);
	}

	public override float GetDamage() => _damage;
}
