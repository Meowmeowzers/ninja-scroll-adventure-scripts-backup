using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    public bool isReadyToAttack = true;
    public float timeToAttack = 2f;

    public void InitiateAttack(Stats stats){
        weapon.Execute(stats);
        if(isReadyToAttack) StartCoroutine(CAttackCooldown());
    }

    public IEnumerator CAttackCooldown(){
		isReadyToAttack = false;
		yield return new WaitForSeconds(timeToAttack);
		isReadyToAttack = true;
	}
}
