using System.Collections;
using UnityEngine;

public class PatrolState: AIState
{
	Vector2 randomDirection;
	Coroutine coroutine;
	bool isPatrolling = false;

	public override void EnterState(AIStateManager context){
		Debug.Log("Patrolling");
		randomDirection = Random.insideUnitCircle.normalized;
		coroutine = context.StartCoroutine(CPatrol(context));
	}
	public override void DoState(AIStateManager context){
		if(isPatrolling && context.aggro.hasTarget){
			context.StopCoroutine(coroutine);
			context.SwitchState(context.chaseState);
		}
	}

	private IEnumerator CPatrol(AIStateManager context){
		context.movement.SetMoveDirection(randomDirection);
		isPatrolling = true;
		yield return new WaitForSeconds(1f);
		isPatrolling = false;
		context.SwitchState(context.idleState);
	}

	
}