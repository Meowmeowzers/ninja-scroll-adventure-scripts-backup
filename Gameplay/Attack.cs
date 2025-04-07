using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    Animator anim;
    public bool isReadyToAttack = true;
    public float timeToAttack = 2f;

	void Awake()
	{
        anim = GetComponent<Animator>();
	}

	public void InitiateAttack(){
        // weapon.Execute(stats);
        if(isReadyToAttack){
            anim.SetTrigger("Attack");
            StartCoroutine(CAttackCooldown());
        }
    }

    public IEnumerator CAttackCooldown(){
		isReadyToAttack = false;
		yield return new WaitForSeconds(timeToAttack);
		isReadyToAttack = true;
	}
}
