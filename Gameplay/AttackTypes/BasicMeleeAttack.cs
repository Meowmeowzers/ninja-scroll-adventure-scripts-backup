using UnityEngine;

[CreateAssetMenu(menuName="Attacks/360Melee")]
public class BasicMeleettack : AttackType
{
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] AudioClip _weaponSound;
	[SerializeField] Vector2 _initialLocationOffset = Vector2.zero;
	[SerializeField] float _offsetDistance = 0.8f;
										
	Vector2 _offset;
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
		weapon.GetComponent<SpriteRenderer>().enabled = true;
      	weapon.GetComponent<BoxCollider2D>().enabled = true;
		if(_weaponSound != null)
			GameManager.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}
	public override void Execute(Weapon weapon, GameObject source){		
		_angle = Mathf.Atan2(weapon.GetDirection().y, weapon.GetDirection().x) * Mathf.Rad2Deg; // get angle from vector2
		_offset = Quaternion.Euler(0, 0, _angle) * Vector2.right * _offsetDistance; // convert angle to vector2
		weapon.transform.SetLocalPositionAndRotation(_offset + _initialLocationOffset, Quaternion.Euler(0f, 0f, _angle - 90f));
	}

}
