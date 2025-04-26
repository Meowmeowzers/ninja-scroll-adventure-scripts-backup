using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/MultiProjectile")]
public class MultiProjectileAttack : AttackType
{
    [SerializeField] GameObject _projectile;
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] float _damage = 1f;
    [SerializeField] int _attacks = 3;
    [SerializeField] float _delayPerAttack = 0.4f;
	[SerializeField] AudioClip _weaponSound;
	
	public override void InitializeWeapon(Weapon weapon)
	{
		if(_weaponSprite != null){
			SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
			BoxCollider2D col = weapon.GetComponent<BoxCollider2D>();

			sr.sprite = _weaponSprite;
			
			Vector2 size = sr.bounds.size;
			Vector2 pivotOffset = (Vector2)(_weaponSprite.bounds.size / 2f) - (_weaponSprite.pivot / _weaponSprite.pixelsPerUnit);
			
			col.size = size;
			col.offset = pivotOffset;
		}
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

	}

	public override void StartWeapon(Weapon weapon){
		
	}
	public override void ExitWeapon(Weapon weapon){
	
	}

    public override void Execute(Weapon weapon, GameObject source){
        
		weapon.StartCoroutine(MultiProjectileRoutine(weapon, source));
	}

    IEnumerator MultiProjectileRoutine(Weapon weapon, GameObject source){
        int i = 0;
        while(i < _attacks){
            
            GameObject projectile = Instantiate(_projectile, weapon.transform.position, Quaternion.identity);

            projectile.GetComponent<Projectile>().Fire(weapon, source);
            
            if(_weaponSound != null)
			    GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);

            i++;
            yield return new WaitForSeconds(_delayPerAttack);
        }
    }
	public override float GetDamage() => _damage;
}
