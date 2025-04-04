public abstract class AIState
{
    protected float minDuration = 2f;
    
    public abstract void EnterState(AIStateManager context);
    public abstract void DoState(AIStateManager context);
}
