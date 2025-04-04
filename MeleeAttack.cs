using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float baseDamage = 2f;
    public float extraDamage = 0f;
    public float timeToAttack = 2f;
	public bool isReadyToAttack = true;

    public void Attack(){
        Debug.Log("Attacked");
        if(isReadyToAttack){
			StartCoroutine(CAttackCooldown());
		}
    }

    public IEnumerator CAttackCooldown(){
		isReadyToAttack = false;
		yield return new WaitForSeconds(timeToAttack);
		isReadyToAttack = true;
	}
}
