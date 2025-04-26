using System.Collections.Generic;
using UnityEngine;

public abstract class AttackType : ScriptableObject
{
    public abstract void InitializeWeapon(Weapon weapon);
	public abstract void StartWeapon(Weapon weapon);
	public abstract void ExitWeapon(Weapon weapon);
	public virtual void Execute(Weapon weapon, GameObject source){}
	public abstract float GetDamage();
	public virtual List<DamageType> GetDamageType(){
		return new(){DamageType.Unknown};
	}
}
