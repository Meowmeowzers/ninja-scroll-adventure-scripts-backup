using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO nexttime
[CreateAssetMenu(menuName="Attacks/TackleAttack")]
public class TackleAttack : AttackType
{
    [SerializeField] float tackleSpeed = 10f;
    [SerializeField] float tackleDuration = 0.3f;
    [SerializeField] LayerMask hitMask;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Sprite _weaponSprite;
	[SerializeField] float _damage = 1f;
	[SerializeField] List<DamageType> _damageType = new(){DamageType.MeleePhysical};
	[SerializeField] AudioClip _weaponSound;
    IEnumerator _ref;
										

    public override void InitializeWeapon(Weapon weapon)
	{
		if(_weaponSprite != null){
			SpriteRenderer sr = weapon.GetComponent<SpriteRenderer>();
			BoxCollider2D col = weapon.GetComponent<BoxCollider2D>();

			sr.sprite = _weaponSprite;
						
			col.size = sr.bounds.size;
			col.offset = (Vector2)(_weaponSprite.bounds.size / 2f) - (_weaponSprite.pivot / _weaponSprite.pixelsPerUnit);;
		}
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
	}

	public override void StartWeapon(Weapon weapon){
		weapon.GetComponent<SpriteRenderer>().enabled = true;
      	weapon.GetComponent<BoxCollider2D>().enabled = true;
		if(_weaponSound != null)
			GameManager.instance.audioPlayer.PlaySound(_weaponSound, 0.8f);
	}
	public override void ExitWeapon(Weapon weapon){
		weapon.GetComponent<SpriteRenderer>().enabled = false;
      	weapon.GetComponent<BoxCollider2D>().enabled = false;
		weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        // weapon.StopCoroutine(_ref);
	}

    public override void Execute(Weapon weapon, GameObject source)
    {
        // _ref = Tackle(weapon, source);
        // weapon.StartCoroutine(Tackle(weapon, source));
        Rigidbody2D rb = source.GetComponent<Rigidbody2D>();
        Vector2 targetDirection = weapon.GetDirection();

        Debug.Log(rb + " " + targetDirection);

        rb.AddForce(targetDirection * tackleSpeed);

        if (rb == null || targetDirection == null)
            return;
    }

	 private IEnumerator Tackle(Weapon weapon, GameObject source)
    {
      yield break;

        // float timer = 0f;

        

        // while (timer < tackleDuration){

        //     Collider2D hit = Physics2D.OverlapCircle(source.transform.position, 0.5f, hitMask);
        //     if (hit != null && hit.TryGetComponent(out IDamageable dmg) && hit.gameObject != source)
        //     {
        //         dmg.DamageHealth(_damage, new List<DamageType>());
        //         if (hitEffect) Instantiate(hitEffect, hit.transform.position, Quaternion.identity);
        //         break;
        //     }

        //     timer += Time.deltaTime;
        //     yield return null;
        // }

        // rb.velocity = Vector2.zero;
    }

	public override float GetDamage() => _damage;
	public override List<DamageType> GetDamageType() => _damageType;
}
