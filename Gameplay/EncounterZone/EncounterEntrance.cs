using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterEntrance : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player")){
            GetComponentInParent<EncounterZone>().ZoneStart();
        }
	}

    void StartZone(){

    }
}
