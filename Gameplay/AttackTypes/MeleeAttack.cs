using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Attacks/Melee")]
public class Meleettack : AttackType
{
	public override void Execute(Stats stats){
		Debug.Log("Melee");
	}
}
