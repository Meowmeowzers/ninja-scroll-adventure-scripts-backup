using UnityEngine;

[CreateAssetMenu(menuName = "State/ChaseToAttack")]
public class ChaseState: State
{
	[SerializeField] float minDistanceToAttack = 1.2f;

	public override void EnterState(EnemyController ai){
	}
	
	public override void UpdateState(EnemyController ai){
		if(ai.GetController().GetAggroRange().DoesTargetExist()){
			
			ai.GetController().Move(ai.GetController().GetAggroRange().GetTargetDirection());

			if(Vector2.Distance(ai.gameObject.transform.position, ai.GetController().GetAggroRange().GetTarget()) < minDistanceToAttack){
				ai.SwitchState(ai.attackState);
			}
		}
		else {
			ai.SwitchState(ai.patrolState);
		}
	}
}