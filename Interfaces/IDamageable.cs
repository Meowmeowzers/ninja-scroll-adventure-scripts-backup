using System.Collections.Generic;

public interface IDamageable
{
    public abstract void DamageHealth(float amount, List<DamageType> damageType);
    public abstract void RestoreHealth(float amount);
}
