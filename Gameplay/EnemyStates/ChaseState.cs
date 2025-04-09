using UnityEngine;

[CreateAssetMenu(menuName = "State/ChaseToAttack")]
public class ChaseState: State
{
	[SerializeField] float minDistanceToAttack = 1.2f;

	public override void EnterState(EnemyController ai){
	}
	
	public override void UpdateState(EnemyController ai){
		if(ai.GetController().GetAggroRange().CheckTargetExist()){
			
			ai.GetController().Move(ai.GetController().GetAggroRange().targetDirection);

			if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().target) < minDistanceToAttack){
				ai.SwitchState(ai.attackState);
			}
		}
		else ai.SwitchState(ai.patrolState);
	}
}