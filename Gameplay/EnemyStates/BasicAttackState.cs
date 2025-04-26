using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Attack")]
public class BasicAttackState : State
{
	[SerializeField] float minDistanceToAttack = 1.2f;
	[SerializeField] float attackDelay = 1f;
	bool _delayDone = false;
	IEnumerator _ref;

	public override void EnterState(EnemyController ai){
		ai.GetController().Move(Vector2.zero);
		_ref = AttackDelayRoutine(attackDelay);
		ai.StartCoroutine(_ref);
	}

	public override void UpdateState(EnemyController ai){
		if (Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) < minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()
		&& ai.GetController().GetAttack().CheckIfReadyToAttack()
		&& _delayDone){

			ai.GetController().GetMovement().SetFacingDirection(ai.GetController().GetAggroRange().GetTargetDirection());
			ai.GetController().Attack();
		}
		else if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) > minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()){
			ai.SwitchState(ai.chaseState);
		}
	}

	public override void ExitState(EnemyController ai){
		ai.StopCoroutine(_ref);
		_delayDone = false;
	}

	IEnumerator AttackDelayRoutine(float delay){
		yield return new WaitForSeconds(delay);
		_delayDone = true;
	}
}