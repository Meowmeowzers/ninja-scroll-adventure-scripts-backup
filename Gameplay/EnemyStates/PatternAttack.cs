using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/PatternAttack")]
public class PatternAttack : State
{
    [SerializeField] float _minDistanceToAttack = 1.2f;
	[SerializeField] float _attackDelay = 1f;
	[SerializeField] float _randomDelay = 2f;
	bool _delayDone = false;
	IEnumerator _ref;

    public override void EnterState(EnemyController ai){
		ai.GetController().Move(Vector2.zero);
		_ref = AttackDelayRoutine(_attackDelay);
		ai.StartCoroutine(_ref);
	}

	public override void UpdateState(EnemyController ai){
		if (Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) < _minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()
		&& ai.GetController().GetAttack().CheckIfReadyToAttack()
		&& _delayDone){

			ai.GetController().GetMovement().SetFacingDirection(ai.GetController().GetAggroRange().GetTargetDirection());
			ai.GetController().Attack();
            ai.GetController().GetAttack().GetWeapon().NextAttack();
		}
		else if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) > _minDistanceToAttack
		&& ai.GetController().GetAggroRange().DoesTargetExist()){
			ai.SwitchState(ai.chaseState);
		}
	}

	public override void ExitState(EnemyController ai){
		_delayDone = false;
		ai.StopCoroutine(_ref);
	}

	IEnumerator AttackDelayRoutine(float delay){
		yield return new WaitForSeconds(delay + Random.Range(0, _randomDelay));
		_delayDone = true;
	}
}
