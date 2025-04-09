using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/IdleToPatrol")]
public class IdleState: State
{
	[SerializeField] float _duration = 1f;
	
	[Range(0, 10f)]
	[SerializeField] 
	float _randomAddDuration = 0f;
	float _newDuration;

	public override void EnterState(EnemyController ai){
		ai.GetController().Move(Vector2.zero);
		ai.StartCoroutine(GoPatrolRoutine(ai));
	}
	
	private IEnumerator GoPatrolRoutine(EnemyController ai){
		_newDuration =_duration + Random.Range(0, _randomAddDuration);
		yield return new WaitForSeconds(_newDuration);
		ai.SwitchState(ai.patrolState);
	}

	public override void ExitState(EnemyController ai)
	{
		ai.StopCoroutine(nameof(GoPatrolRoutine));
	}

}