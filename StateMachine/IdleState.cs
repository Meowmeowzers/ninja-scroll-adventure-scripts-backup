using System.Collections;
using UnityEngine;

public class IdleState: AIState
{
	public override void EnterState(AIStateManager context){
		// Debug.Log("Idle");
		context.movement.SetMoveDirection(Vector2.zero);
		context.StartCoroutine(CGoPatrol(context));
	}
	public override void DoState(AIStateManager context){}
		
	private IEnumerator CGoPatrol(AIStateManager context){
		yield return new WaitForSeconds(minDuration);
		context.SwitchState(context.patrolState);
	}
}