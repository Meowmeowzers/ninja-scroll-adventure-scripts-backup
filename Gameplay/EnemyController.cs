using UnityEngine;

public class EnemyController : MonoBehaviour
{
    UnitController _unitController;
    [SerializeField] State _currentState;

	public State idleState;
	public State patrolState;
	public State chaseState;
	public State attackState;

	void Awake(){
        _unitController = GetComponent<UnitController>();
    }

	void Start(){
		_currentState = idleState;
		_currentState.EnterState(this);
	}

	void Update()
	{
		_currentState.UpdateState(this);
	}

    public void SwitchState(State state)
	{
		_currentState.ExitState(this);
		_currentState = state;
		_currentState.EnterState(this);
	}

	public UnitController GetController(){
		return _unitController;
	}
}
