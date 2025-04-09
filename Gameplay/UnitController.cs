using UnityEngine;

public enum CharacterState {Idle, Moving, Attacking, KO}

[RequireComponent(typeof(Movement), typeof(Attack), typeof(Stats))]
public class UnitController: MonoBehaviour
{
    [SerializeField] CharacterState _currentState = CharacterState.Idle;

    Animator anim;
    Rigidbody2D rb;
    Collider2D col;
	Movement movement;
	Attack attack;
	Stats stats;
	PlayerInteraction playerInteraction;
    EnemyController ai;
    AggroRange aggro;

	void Awake()
	{
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
		movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        stats = GetComponent<Stats>();
        ai = GetComponent<EnemyController>();
        playerInteraction = GetComponentInChildren<PlayerInteraction>();
        aggro = GetComponentInChildren<AggroRange>();
        stats.SubscribeOnUnitKO(OnKO);
	}

	private void OnKO()
	{
		_currentState = CharacterState.KO;

        anim.SetBool("isDead", true);
        col.enabled = false;
        movement.enabled = false;
        attack.enabled = false;
        
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

	public void SwitchState(CharacterState state){
        _currentState = state;
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

    public Attack GetAttack(){
        return attack;
    }
    public Movement GetMovement(){
        return movement;
    }
	public PlayerInteraction GetPlayerInteraction() { 
        return playerInteraction; 
    }

    public AggroRange GetAggroRange(){
        return aggro;
    }

}
