using UnityEngine;

public class ChaseState: AIState
{
	public float minDistanceToAttack = 1.2f;
	public override void EnterState(AIStateManager context){
		// Debug.Log("Chasing");
	}
	public override void DoState(AIStateManager context){
		if(context.aggro.hasTarget){
			context.movement.SetMoveDirection(context.aggro.targetDirection);
			if(Vector2.Distance(context.transform.position, context.aggro.target) < minDistanceToAttack
			&& context.meleeAttack.isReadyToAttack){
				context.SwitchState(context.meleeAttackState);
			}
		}
		else context.SwitchState(context.idleState);
	}
}