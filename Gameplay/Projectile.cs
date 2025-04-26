using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f;
    [SerializeField] float _timeBeforeDestroy = 0.1f;
    [SerializeField] float _speed = 1f;
    [SerializeField] List<DamageType> _damageType;
    [SerializeField] GameObject _breakParticle;
    Animator _anim;
    Rigidbody2D _rb;
    GameObject _source;
    float _damage = 1f;

	void Awake()
	{
		_anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
        StartCoroutine(LifeTimeRoutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.GetComponent<IDamageable>() != null
        && collision.gameObject != _source){
            collision.GetComponent<IDamageable>().DamageHealth(_damage, _damageType);
		    ProjectileBreak();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Unwalkable")){
            ProjectileBreak();
        }
	}

    public void Fire(Weapon weapon, GameObject source)
	{
        _source = source;
        _damage = weapon.GetDamage();
        _anim.SetBool("Normal",true);

        float _angle = Mathf.Atan2(weapon.GetDirection().y, weapon.GetDirection().x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, _angle - 90f);

		_rb.AddForce(weapon.GetDirection() * _speed, ForceMode2D.Impulse);
    }
    public void FireToDirection(Weapon weapon, Vector2 direction, GameObject source)
	{
        _source = source;
        _damage = weapon.GetDamage();
        _anim.SetBool("Normal",true);
         transform.rotation = Quaternion.FromToRotation(Vector2.up, direction);
		_rb.AddForce(direction * _speed, ForceMode2D.Impulse);
    }

    IEnumerator LifeTimeRoutine(){
        yield return new WaitForSeconds(_lifetime);
        ProjectileBreak();
    }

	void ProjectileBreak(){
        _anim.SetTrigger("Destroy"); // will be hidden
        _rb.velocity = Vector2.zero;
        if(_breakParticle != null) Instantiate(_breakParticle, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false; // for now
        Invoke(nameof(DestroyProjectile), _timeBeforeDestroy);
    }

	void DestroyProjectile()
	{
        StopAllCoroutines();
		Destroy(gameObject);
	}

}
