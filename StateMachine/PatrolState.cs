using System.Collections;
using UnityEngine;

public class PatrolState: AIState
{
	private Vector2 _randomDirection;
	private Coroutine _coroutine;
	private bool _isPatrolling = false;

	private AIStateMachine ai;

	public PatrolState(AIStateMachine ai){
		this.ai = ai;
	}

	public override void EnterState(){
		// Debug.Log("Patrolling");
		_randomDirection = Random.insideUnitCircle.normalized;
		_coroutine = ai.StartCoroutine(CPatrol());
	}

	public override void UpdateState(){
		if(_isPatrolling && ai.aggro.hasTarget){
			ai.StopCoroutine(_coroutine);
			ai.SwitchState(new ChaseState(ai));
		}
	}

	private IEnumerator CPatrol(){
		ai.movement.SetMoveDirection(_randomDirection);
		_isPatrolling = true;
		yield return new WaitForSeconds(1f);
		_isPatrolling = false;
		ai.SwitchState(new IdleState(ai));
	}

	
}