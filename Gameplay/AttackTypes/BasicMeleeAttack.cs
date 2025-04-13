using UnityEngine;

[CreateAssetMenu(menuName="Attacks/BasicMelee")]
public class BasicMeleettack : AttackType
{
	[SerializeField] Vector2 _initialLocationOffset = Vector2.zero;
	[SerializeField] float _offsetDistance = 0.8f;
										
	Vector2 _offset;
	float _angle;

	public override void InitializeWeapon(Weapon weapon){
		weapon.GetComponent<SpriteRenderer>().enabled = true;
      	weapon.GetComponent<BoxCollider2D>().enabled = true;
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
