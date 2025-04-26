using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/LineOfSightAttack")]
public class LineOfSightAttackState : State
{
	[SerializeField] float _minDistanceToAttack = 1.2f;
	[SerializeField] float _initialattackDelay = 1f;
	[SerializeField] LayerMask _lineOfSightMask; // I dont wanna deal with bitwise operations
	bool _initialdelayDone = false;
	IEnumerator _ref;

	public override void EnterState(EnemyController ai){
		ai.GetController().Move(Vector2.zero);
		_ref = AttackDelayRoutine(_initialattackDelay);
		ai.StartCoroutine(_ref);
	}

	public override void UpdateState(EnemyController ai){
		if (Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) < _minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()
		&& ai.GetController().GetAttack().CheckIfReadyToAttack()
		&& _initialdelayDone){

			ai.GetController().GetMovement().SetFacingDirection(ai.GetController().GetAggroRange().GetTargetDirection());
			
			RaycastHit2D hit = Physics2D.Raycast(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTargetDirection(), _minDistanceToAttack, _lineOfSightMask);
			if (hit.collider != null && !hit.collider.CompareTag("Player")) return;

			ai.GetController().Attack();
		}
		else if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) > _minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()){
			ai.SwitchState(ai.chaseState);
		}
	}

	public override void ExitState(EnemyController ai){
		_initialdelayDone = false;
		ai.StopCoroutine(_ref);
	}

	IEnumerator AttackDelayRoutine(float delay){
		yield return new WaitForSeconds(delay);
		_initialdelayDone = true;
	}
}