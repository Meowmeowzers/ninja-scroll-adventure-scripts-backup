using UnityEngine;

[CreateAssetMenu(menuName="Attacks/BasicProjectile")]
public class RangedAttack : AttackType
{
	[SerializeField] GameObject _projectile;
	float _angle;

	public override void InitializeWeapon(Weapon weapon){
	
	}
	public override void ExitWeapon(Weapon weapon){
	
	}

    public override void Execute(Weapon weapon, GameObject source){
		GameObject projectile = Instantiate(_projectile, weapon.transform.position, Quaternion.identity);

		_angle = Mathf.Atan2(weapon.GetDirection().y, weapon.GetDirection().x) * Mathf.Rad2Deg;

		projectile.transform.rotation = Quaternion.Euler(0f, 0f, _angle - 90f);
		projectile.GetComponent<Projectile>().Fire(weapon, source);
	}
}
