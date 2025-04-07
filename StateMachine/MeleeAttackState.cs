using System.Collections;
using UnityEngine;

public class MeleeAttackState: AIState
{
	private AIStateMachine ai;

	public MeleeAttackState(AIStateMachine ai){
		this.ai = ai;
	}

	public override void EnterState(){
		// Debug.Log("Melee");
		ai.movement.SetMoveDirection(Vector2.zero);
		ai.attack.InitiateAttack();
		ai.SwitchState( new ChaseState(ai));
	}
}