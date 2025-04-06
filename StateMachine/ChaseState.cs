using UnityEngine;

public class ChaseState: AIState
{
	private AIStateMachine ai;
	public float minDistanceToAttack = 1.2f;

	public ChaseState(AIStateMachine ai){
		this.ai = ai;
	}
	
	public override void UpdateState(){
		if(ai.aggro.hasTarget){
			ai.movement.SetMoveDirection(ai.aggro.targetDirection);
			if(Vector2.Distance(ai.transform.position, ai.aggro.target) < minDistanceToAttack
			&& ai.attack.isReadyToAttack){
				ai.SwitchState(new MeleeAttackState(ai));
			}
		}
		else ai.SwitchState( new IdleState(ai));
	}
}