public abstract class AIState
{
    protected float _duration = 2f;
    
    public virtual void EnterState(){}
    public virtual void UpdateState(){}
    public virtual void PhysicsUpdate(){}
    public virtual void ExitState(){}
}

