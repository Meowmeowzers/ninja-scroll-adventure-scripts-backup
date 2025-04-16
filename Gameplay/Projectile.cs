using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f;
    [SerializeField] float _timeBeforeDestroy = 0.2f;
    [SerializeField] float _speed = 1f;
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
            collision.GetComponent<IDamageable>().DamageHealth(_damage);
		    Break();
        }
	}

    public void Fire(Weapon weapon, GameObject source)
	{
        _source = source;
        _damage = weapon.GetDamage();
        _anim.SetBool("Normal",true);
		_rb.AddForce(weapon.GetDirection() * _speed, ForceMode2D.Impulse);
    }

    IEnumerator LifeTimeRoutine(){
        yield return new WaitForSeconds(_lifetime);
        Break();
    }

	void Break(){
        _anim.SetTrigger("Destroy");
        _rb.velocity = Vector2.zero;
        Invoke(nameof(DestroyProjectile), _timeBeforeDestroy);
    }

	void DestroyProjectile()
	{
        StopAllCoroutines();
		Destroy(gameObject);
	}

}
