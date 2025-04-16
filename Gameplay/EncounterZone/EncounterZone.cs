using System;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{
    [SerializeField] EncounterSpawner[] _spawns;
    [SerializeField] EncounterEntrance[] _entrances;
    [SerializeField] EncounterBarrier[] _barriers;
    [SerializeField] AudioClip _startSound;
    [SerializeField] AudioClip _endSound;
    int _currentSpawn = 0;
    bool _hasStarted = false;

    event Action Finished;

	void Awake()
	{
        Finished += OnZoneDone;
        _spawns = GetComponentsInChildren<EncounterSpawner>();
        _entrances = GetComponentsInChildren<EncounterEntrance>();
        _barriers = GetComponentsInChildren<EncounterBarrier>();
        foreach(var i in _barriers) i.gameObject.SetActive(false);
	}

	void Update()
	{
        if(_hasStarted && _currentSpawn == 0){
            _hasStarted = false;
            Finished.Invoke();
        }
	}

	public void ZoneStart(){
        if(!_hasStarted){
            _hasStarted = true;
            foreach(var i in _entrances){
                i.gameObject.SetActive(false);
            }
            foreach(var i in _barriers){
                i.gameObject.SetActive(true);   
            }
            foreach(var i in _spawns){
                i.Spawn(OnReduce);
                _currentSpawn++;
            }
            GameManager.PlaySound(_startSound);
            GameManager.SwitchToEncounterMusic();
        }
    }

    void OnReduce(){
        _currentSpawn--;
    }

    void OnZoneDone(){
        foreach(var i in _barriers){
            i.gameObject.SetActive(false);
        }
        GameManager.PlaySound(_endSound);
        GameManager.SwitchToMainMusic();
        
    }

    void OnDestroy(){
        Finished -= OnZoneDone;
    }
}
