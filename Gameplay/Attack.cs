using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Weapon _weapon;
    [SerializeField] float _timeToAttack = 2f;
    [SerializeField] float _minTimeToAttacking = 0.2f;
    [SerializeField] bool _isAttacking = false;
    Animator _anim;
    Movement _movement;
    bool _isReadyToAttack = true;


	void Awake()
    {
        _anim = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _weapon = GetComponentInChildren<Weapon>();
	}

	void Start()
	{
		_weapon.ExitWeapon();
	}

	public void InitiateAttack(Vector2 facingDirection){
        if(_isReadyToAttack && !_isAttacking){
            _anim.SetTrigger("Attack");
            _movement.SetCanMove(false);
            _isAttacking = true;
            _isReadyToAttack = false;
            
            _weapon.StartWeapon();
            _weapon.Execute(facingDirection, gameObject);

            StartCoroutine(CAttackCooldown());
            StartCoroutine(CAttackingCooldown());
        }
    }

	private IEnumerator CAttackingCooldown()
	{
		yield return new WaitForSeconds(_minTimeToAttacking);
        _movement.SetCanMove(true);
        _weapon.ExitWeapon();
		_isAttacking = false;
	}

	public IEnumerator CAttackCooldown(){
		yield return new WaitForSeconds(_timeToAttack);
		_isReadyToAttack = true;
	}

    public bool GetIsAttacking(){
        return _isAttacking;
    }

    public bool CheckIfReadyToAttack(){
        return _isReadyToAttack;
    }

	void OnDisable()
	{
		StopAllCoroutines();
	}
}
