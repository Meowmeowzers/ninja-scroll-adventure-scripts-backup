using System;
using UnityEngine;

public class AIStateMachine: MonoBehaviour
{
    public AIState currentState;
	public Stats stats;
	public Movement movement;
	public AggroRange aggro;
	public Attack attack;
	
    void Awake(){
        stats = GetComponent<Stats>();
		movement = GetComponent<Movement>();
        aggro = GetComponentInChildren<AggroRange>();
        attack = GetComponent<Attack>();
    }
	void Start()
	{
        currentState = new IdleState(this);
        currentState.EnterState();
	}

	void Update(){
		currentState.UpdateState();
	}

	public void SwitchState(AIState state){
		currentState = state;
		currentState.ExitState();
		currentState.EnterState();
	}
	
}
