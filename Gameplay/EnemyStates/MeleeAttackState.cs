using UnityEngine;

[CreateAssetMenu(menuName = "State/Attack")]
public class MeleeAttackState: State
{
	[SerializeField] float minDistanceToAttack = 1.2f;

	public override void EnterState(EnemyController ai){
		ai.GetController().Move(Vector2.zero);
		ai.GetController().Attack();
	}

	public override void UpdateState(EnemyController ai){
		if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().target) < minDistanceToAttack
		&& ai.GetController().GetAggroRange().CheckTargetExist()
		&& ai.GetController().GetAttack().CheckIfReadyToAttack()){
			ai.GetController().GetMovement().SetFacingDirection(ai.GetController().GetAggroRange().targetDirection);
			ai.GetController().Attack();
		}
		else if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().target) > minDistanceToAttack
		&& ai.GetController().GetAggroRange().CheckTargetExist()){
			ai.SwitchState(ai.chaseState);
		}
	}

	public override void ExitState(EnemyController ai){

	}
}