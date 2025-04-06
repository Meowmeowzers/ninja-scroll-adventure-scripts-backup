using System.Collections;
using UnityEngine;

public class IdleState: AIState
{
	private AIStateMachine ai;

	public IdleState(AIStateMachine ai){
		this.ai = ai;
	}

	public override void EnterState(){
		// Debug.Log("Idle");
		ai.movement.SetMoveDirection(Vector2.zero);
		ai.StartCoroutine(CGoPatrol(ai));
	}
	
	private IEnumerator CGoPatrol(AIStateMachine ai){
		yield return new WaitForSeconds(_duration);
		ai.SwitchState(new PatrolState(ai));
	}


}