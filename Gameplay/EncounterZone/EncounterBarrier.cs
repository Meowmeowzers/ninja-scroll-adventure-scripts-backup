using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterBarrier : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player")){
            Debug.Log("Hello");
            // GetComponentInParent<EncounterZone>().
        }
	}

    void StartZone(){
        
    }
}
