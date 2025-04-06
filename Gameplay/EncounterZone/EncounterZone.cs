using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{
    [SerializeField] EncounterSpawner[] spawns;
    [SerializeField] EncounterEntrance[] entrances;
    [SerializeField] EncounterBarrier[] barriers;
    [SerializeField] int currentSpawn = 0;
    [SerializeField] bool hasStarted = false;

    event Action Started;
    event Action Finished;


	void Awake()
	{
        Finished += ZoneDone;
	}

	void Update()
	{
        if(hasStarted && currentSpawn == 0) Finished.Invoke();
	}

	public void ZoneStart(){
        if(!hasStarted){
            Debug.Log("Zone Start");
            hasStarted = true;
            foreach(var i in entrances){
                i.gameObject.SetActive(false);
            }
            foreach(var i in barriers){
                i.gameObject.SetActive(true);   
            }
            foreach(var i in spawns){
                i.Spawn();
                currentSpawn++;
            }
        }
    }
    void ZoneDone(){
        Debug.Log("Zone Done");
        foreach(var i in barriers){
            i.gameObject.SetActive(false);
        }
    }

    void OnDestroy(){
        Finished -= ZoneDone;
    }
}
