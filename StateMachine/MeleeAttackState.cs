using System.Collections;
using UnityEngine;

public class MeleeAttackState: AIState
{
	public override void EnterState(AIStateManager context){
		Debug.Log("Melee");
		context.movement.SetMoveDirection(Vector2.zero);
		context.meleeAttack.Attack();
		context.SwitchState(context.chaseState);
	}
	public override void DoState(AIStateManager context){
		
	}



}