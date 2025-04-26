using System;
using UnityEngine;

public class EncounterZone : MonoBehaviour
{
    [SerializeField] AudioClip _startSound;
    [SerializeField] AudioClip _endSound;
    [SerializeField] bool _isBossEncounter = false;
    EncounterSpawner[] _spawns;
    EncounterEntrance[] _entrances;
    EncounterBarrier[] _barriers;
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
            GameManager.instance.audioPlayer.PlaySound(_startSound);

            if(!_isBossEncounter){
                GameManager.instance.audioPlayer.SwitchToEncounterMusic();
            }
            else{
                GameManager.instance.audioPlayer.SwitchToBossMusic();
            }
        }
    }

    void OnReduce(){
        _currentSpawn--;
    }

    void OnZoneDone(){
        foreach(var i in _barriers){
            i.gameObject.SetActive(false);
        }
        GameManager.instance.audioPlayer.PlaySound(_endSound);
        
        if(!_isBossEncounter){
            GameManager.instance.audioPlayer.SwitchToMainMusic();
        }
        else{
            GameManager.instance.WinGame();
        }            

    }

    void OnDestroy(){
        Finished -= OnZoneDone;
    }
}
