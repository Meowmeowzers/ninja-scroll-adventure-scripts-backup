using System;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{
    [SerializeField] EncounterSpawner[] spawns;
    [SerializeField] EncounterEntrance[] entrances;
    [SerializeField] EncounterBarrier[] barriers;
    [SerializeField] int currentSpawn = 0;
    [SerializeField] bool hasStarted = false;

    event Action Finished;

	void Awake()
	{
        Finished += OnZoneDone;
	}

	void Update()
	{
        if(hasStarted && currentSpawn == 0){
            hasStarted = false;
            Finished.Invoke();
        }
	}

	public void ZoneStart(){
        if(!hasStarted){
            hasStarted = true;
            foreach(var i in entrances){
                i.gameObject.SetActive(false);
            }
            foreach(var i in barriers){
                i.gameObject.SetActive(true);   
            }
            foreach(var i in spawns){
                i.Spawn(OnReduce);
                currentSpawn++;
            }
        }
    }

    void OnReduce(){
        currentSpawn--;
    }
    void OnZoneDone(){
        Debug.Log("Zone Done");
        foreach(var i in barriers){
            i.gameObject.SetActive(false);
        }
    }

    void OnDestroy(){
        Finished -= OnZoneDone;
    }
}
