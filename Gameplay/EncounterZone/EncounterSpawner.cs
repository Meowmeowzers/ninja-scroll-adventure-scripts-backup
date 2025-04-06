using UnityEngine;
using System;

public class EncounterSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawn;

    void StartZone()
    {
        
    }

    public void Spawn(){
        Instantiate(spawn, transform);
    }

	void OnDestroy()
	{
		
	}
}
