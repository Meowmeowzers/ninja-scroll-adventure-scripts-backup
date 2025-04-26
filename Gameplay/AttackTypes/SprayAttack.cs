using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/SprayAttack")]
public class SprayAttack : AttackType
{
    [SerializeField] GameObject _projectile;
	[SerializeField] Sprite _weaponSprite;
	[SerializeField] float _damage = 1f;
    [SerializeField] int _attacks = 3;
    [SerializeField] float _delayPerAttack = 0.4f;
    [SerializeField] private float startAngle = 0f;
    [SerializeField] private float endAngle = 360f;
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
    public override void StartWeapon(Weapon weapon){}
	public override void ExitWeapon(Weapon weapon){}

    public override void Execute(Weapon weapon, GameObject source){

		weapon.StartCoroutine(SprayAttackRoutine(weapon, source));
	}

    IEnumerator SprayAttackRoutine(Weapon weapon, GameObject source){
        int i = 0;
        while(i < _attacks){
            
            float randomAngle = Random.Range(startAngle, endAngle);
            Vector2 direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
            
            GameObject projectile = Instantiate(_projectile, weapon.transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().FireToDirection(weapon, direction, source);
            
            if(_weaponSound != null)
			    GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);

            i++;
            yield return new WaitForSeconds(_delayPerAttack);
        }
    }
	public override float GetDamage() => _damage;
}
