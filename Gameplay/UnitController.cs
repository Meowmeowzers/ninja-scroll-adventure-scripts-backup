using System;
using System.Collections;
using UnityEngine;

public enum CharacterState {Idle, Moving, Attacking, KO}

[RequireComponent(typeof(Stats), typeof(Movement), typeof(Attack))]
public class UnitController: MonoBehaviour
{
    [SerializeField] CharacterState _currentState = CharacterState.Idle;

    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Collider2D col;
	Movement movement;
	Attack attack;
	Stats stats;
	PlayerInteraction playerInteraction;
    EnemyController ai;
    AggroRange aggro;
    Weapon weapon;

	void Awake()
	{
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
		movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        stats = GetComponent<Stats>();
        ai = GetComponent<EnemyController>();
        playerInteraction = GetComponentInChildren<PlayerInteraction>();
        aggro = GetComponentInChildren<AggroRange>();
        weapon = GetComponentInChildren<Weapon>();
        stats.SubscribeOnUnitKO(OnKO);
        stats.SubscribeOnUnitDamaged(OnDamaged);

	}

	void Update()
	{
        if(_currentState != CharacterState.KO){
            if(attack.GetIsAttacking()) _currentState = CharacterState.Attacking;
            else if(movement.GetIsMoving()) _currentState = CharacterState.Moving;
            else _currentState = CharacterState.Idle;
        }
	}

    public void Move(Vector2 input){
        if(_currentState != CharacterState.KO)
            movement.SetMoveDirection(input);
    }
    public void Attack(){
        if(_currentState != CharacterState.KO)
            attack.InitiateAttack(movement.GetFacingDirection());
    }

    private void OnKO()
	{
		_currentState = CharacterState.KO;

        anim.SetBool("isDead", true);
        col.enabled = false;
        movement.enabled = false;
        attack.enabled = false;
        weapon.enabled = false;
        if(playerInteraction != null){
            playerInteraction.enabled = false;
        }
        if(aggro != null){
            aggro.enabled = false;
        }
        if(ai != null){
            ai.enabled = false;
        }
	}

    private void OnDamaged(){
        StartCoroutine(HitAnimationRoutine());
    }

	private IEnumerator HitAnimationRoutine()
	{
        sr.color = Color.HSVToRGB(0,0.25f,1f);
		yield return new WaitForSeconds(0.1f);
        sr.color = Color.HSVToRGB(0,0,1f);
	}

	public void SwitchState(CharacterState state){
        _currentState = state;
    }

    public Attack GetAttack() => attack;
    public Movement GetMovement() => movement;
	public PlayerInteraction GetPlayerInteraction() => playerInteraction;
    public AggroRange GetAggroRange() => aggro;
    public CharacterState GetState() => _currentState;

}
