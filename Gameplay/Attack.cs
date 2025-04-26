using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float _timeToAttack = 2f;
    [SerializeField] float _extraRandomTimeToAttack = 0f;
    [SerializeField] float _attackStat = 1f;
    Weapon _weapon;
    Animator _anim;
    Movement _movement;
    bool _isAttacking = false;
    float _minTimeToAttacking = 0.2f;
    bool _isReadyToAttack = true;

	void Awake()
    {
        _anim = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _weapon = GetComponentInChildren<Weapon>();
	}

	public void InitiateAttack(Vector2 facingDirection){
        if(_isReadyToAttack && !_isAttacking){
            _anim.SetTrigger("Attack");
            _movement.SetCanMove(false);
            _isAttacking = true;
            _isReadyToAttack = false;
            
            _weapon.StartWeapon(_attackStat);
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
		yield return new WaitForSeconds(_timeToAttack + Random.Range(0, _extraRandomTimeToAttack));
		_isReadyToAttack = true;
	}

    public bool GetIsAttacking(){
        return _isAttacking;
    }

    public bool CheckIfReadyToAttack(){
        return _isReadyToAttack;
    }

    public void SwitchWeapon(int index){
        _weapon.SwitchWeapon(index);
    }
    public Weapon GetWeapon() => _weapon;

	void OnDisable()
	{
		StopAllCoroutines();
	}
}
