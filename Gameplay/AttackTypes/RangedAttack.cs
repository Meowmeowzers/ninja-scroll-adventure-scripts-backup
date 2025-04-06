using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/Ranged")]
public class RangedAttack : AttackType
{
    public override void Execute(Stats stats){
		Debug.Log("Ranged");
	}
}
