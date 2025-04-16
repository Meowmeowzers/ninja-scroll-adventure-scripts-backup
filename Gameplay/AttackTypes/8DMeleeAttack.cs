using UnityEngine;

[CreateAssetMenu(menuName="Attacks/8DMelee")]
public class Melee8DAttack : AttackType
{
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] AudioClip _weaponSound;
	[SerializeField] Vector2 _initialLocationOffset = Vector2.zero;
	[SerializeField] Vector2 _offsetUp = new(0, 0.5f);								
	[SerializeField] Vector2 _offsetDown = new(0, -0.3f);
	[SerializeField] Vector2 _offsetLeft = new(-0.4f, 0);
	[SerializeField] Vector2 _offsetRight = new(0.4f, 0);
	[SerializeField] Vector2 _offsetUpRight = new(0.3f, 0.3f);
	[SerializeField] Vector2 _offsetUpLeft = new(-0.3f, 0.3f);
	[SerializeField] Vector2 _offsetDownRight = new(0.3f, -0.3f);
	[SerializeField] Vector2 _offsetDownLeft = new(-0.3f, -0.3f);

	Vector2 _snappedDir;
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
		_snappedDir = GetNearestDirection(weapon.GetDirection());
		_offset = GetOffsetForDirection(_snappedDir);
		
		_angle = Mathf.Atan2(_snappedDir.y, _snappedDir.x) * Mathf.Rad2Deg;
		weapon.transform.SetLocalPositionAndRotation(_initialLocationOffset + _offset, Quaternion.Euler(0, 0, _angle - 90f));
	}

	Vector2 GetNearestDirection(Vector2 dir)
	{
		dir.Normalize();
		float maxDot = float.MinValue;
		Vector2 best = Vector2.zero;

		foreach (var d in directions)
		{
			float dot = Vector2.Dot(dir, d.normalized);
			if (dot > maxDot)
			{
				maxDot = dot;
				best = d;
			}
		}

		return best;
	}

	Vector2 GetOffsetForDirection(Vector2 dir)
	{
		if (dir == Vector2.up) return _offsetUp;
		if (dir == Vector2.down) return _offsetDown;
		if (dir == Vector2.left) return _offsetLeft;
		if (dir == Vector2.right) return _offsetRight;
		if (dir == new Vector2(1, 1)) return _offsetUpRight;
		if (dir == new Vector2(-1, 1)) return _offsetUpLeft;
		if (dir == new Vector2(1, -1)) return _offsetDownRight;
		if (dir == new Vector2(-1, -1)) return _offsetDownLeft;

		return Vector2.zero;
	}

	private static readonly Vector2[] directions = new Vector2[]
	{
		new Vector2(0, 1),    // Up
		new Vector2(1, 1),    // Up-Right
		new Vector2(1, 0),    // Right
		new Vector2(1, -1),   // Down-Right
		new Vector2(0, -1),   // Down
		new Vector2(-1, -1),  // Down-Left
		new Vector2(-1, 0),   // Left
		new Vector2(-1, 1)    // Up-Left
	};
}
