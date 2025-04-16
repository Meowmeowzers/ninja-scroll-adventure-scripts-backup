using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/PatrolToChase")]
public class PatrolState: State
{
	[SerializeField] float _duration = 1f;
	
	[Range(0, 10f)]
	[SerializeField] 
	float _randomAddDuration = 0f;

	Vector2 _randomDirection;
	float _newDuration;
	IEnumerator _ref;

	public override void EnterState(EnemyController ai){
		_randomDirection = Random.insideUnitCircle.normalized;
		_ref = PatrolRoutine(ai);
		ai.StartCoroutine(_ref);
	}

	public override void UpdateState(EnemyController ai){
		if(ai.GetController().GetAggroRange().DoesTargetExist()){
			ai.StopCoroutine(_ref);
			ai.SwitchState(ai.chaseState);
		}
	}

	private IEnumerator PatrolRoutine(EnemyController ai)
	{
		ai.GetController().Move(_randomDirection);
		_newDuration =_duration + Random.Range(0, _randomAddDuration);
		yield return new WaitForSeconds(_newDuration);
		ai.SwitchState(ai.idleState);
	}

	public override void ExitState(EnemyController ai){
		ai.StopCoroutine(_ref);
	}
	
}