using UnityEngine;

public class AIStateManager : MonoBehaviour
{
	AIState currentState;
	public Movement movement;
	public AggroRange aggro;
	public MeleeAttack meleeAttack;

	public IdleState idleState = new();
	public ChaseState chaseState = new();
	public PatrolState patrolState = new();
	public MeleeAttackState meleeAttackState = new();

	void Awake(){
		movement = GetComponent<Movement>();
		aggro = GetComponentInChildren<AggroRange>();
		meleeAttack = GetComponent<MeleeAttack>();
		currentState = idleState;
		currentState.EnterState(this);
	}

	void Update(){
		currentState.DoState(this);
	}

	public void SwitchState(AIState state){
		currentState = state;
		currentState.EnterState(this);
	}
}
