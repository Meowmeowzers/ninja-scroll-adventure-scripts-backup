using UnityEngine;


[System.Serializable]
public abstract class State : ScriptableObject
{    
    public virtual void EnterState(EnemyController ai){}
    public virtual void UpdateState(EnemyController ai){}
    public virtual void PhysicsUpdate(EnemyController ai){}
    public virtual void ExitState(EnemyController ai){}
}

