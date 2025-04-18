using System;
using System.Collections;
using UnityEngine;

public enum CharacterState {Idle, Moving, Attacking, KO}

[RequireComponent(typeof(Stats), typeof(Movement), typeof(Attack))]
public class UnitController: MonoBehaviour
{
    [SerializeField] CharacterState _currentState = CharacterState.Idle;

    Animator _anim;
    SpriteRenderer _sr;
    Rigidbody2D _rb;
    Collider2D _col;
	Movement _movement;
	Attack _attack;
	Stats _stats;
	PlayerInteraction _playerInteraction;
    EnemyController _ai;
    AggroRange _aggro;
    Weapon _weapon;

	void Awake()
	{
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _col = GetComponent<Collider2D>();
		_movement = GetComponent<Movement>();
        _attack = GetComponent<Attack>();
        _stats = GetComponent<Stats>();
        _ai = GetComponent<EnemyController>();
        _playerInteraction = GetComponentInChildren<PlayerInteraction>();
        _aggro = GetComponentInChildren<AggroRange>();
        _weapon = GetComponentInChildren<Weapon>();
        _stats.UnitKO += OnKO;
        _stats.UnitDamaged += OnDamaged;

	}

	void Update()
	{
        if(_currentState != CharacterState.KO){
            if(_attack.GetIsAttacking()) _currentState = CharacterState.Attacking;
            else if(_movement.GetIsMoving()) _currentState = CharacterState.Moving;
            else _currentState = CharacterState.Idle;
        }
	}

    public void Move(Vector2 input){
        if(_currentState != CharacterState.KO)
            _movement.SetMoveDirection(input);
    }
    public void Attack(){
        if(_currentState != CharacterState.KO)
            _attack.InitiateAttack(_movement.GetFacingDirection());
    }
    public void SwitchAttack(int index){
        _attack.SwitchWeapon(index);
    }

    private void OnKO(){
		_currentState = CharacterState.KO;

        _anim.SetBool("isDead", true);
        _col.enabled = false;
        _movement.enabled = false;
        _attack.enabled = false;
        _weapon.ExitWeapon();
        _weapon.enabled = false;

        if(_playerInteraction != null){
            _playerInteraction.enabled = false;
        }
        if(_aggro != null){
            _aggro.enabled = false;
        }
        if(_ai != null){
            _ai.enabled = false;
        }
	}

    private void OnDamaged(){
        StartCoroutine(HitAnimationRoutine());
    }

	private IEnumerator HitAnimationRoutine()
	{
        _sr.color = Color.HSVToRGB(0,0.25f,1f);
		yield return new WaitForSeconds(0.1f);
        _sr.color = Color.HSVToRGB(0,0,1f);
	}

	public void SwitchState(CharacterState state){
        _currentState = state;
    }

    public Attack GetAttack() => _attack;
    public Movement GetMovement() => _movement;
	public PlayerInteraction GetPlayerInteraction() => _playerInteraction;
    public AggroRange GetAggroRange() => _aggro;
    public CharacterState GetState() => _currentState;

}
