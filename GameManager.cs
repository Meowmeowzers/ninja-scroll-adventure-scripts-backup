using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip _mainMusic;
    [SerializeField] AudioClip _encounterMusic;
    [SerializeField] InGameUI _ui;
    public static event Action OnEncounterStart;
    public static event Action OnEncounterEnd;
    static AudioSource _audioSource;
    float _timeMain;
    float _timeEncounter;

    void Awake()
    {
        // if(_instance == null){
        //     _instance = this;
        // }
        // else if(_instance != this){
        //     Destroy(this);
        // }
        // DontDestroyOnLoad(this);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _mainMusic;
        OnEncounterStart += SwitchToEncounter;
        OnEncounterEnd += SwitchToMain;
    }

	void Start()
	{
		_audioSource.Play();
	}

    void SwitchToEncounter(){
        _timeMain = _audioSource.time;
        _audioSource.clip = _encounterMusic;
        _audioSource.time = _timeEncounter;
        _audioSource.Play();
    }

    void SwitchToMain(){
        _timeEncounter = _audioSource.time;
        _audioSource.clip = _mainMusic;
        _audioSource.time = _timeMain;
        _audioSource.Play();
    }

    public static void SwitchToEncounterMusic(){
        OnEncounterStart?.Invoke();
    }
    public static void SwitchToMainMusic(){
        OnEncounterEnd?.Invoke();
    }
	public static void PlaySound(AudioClip clip){
        _audioSource.PlayOneShot(clip);
    }
    public static void PlaySound(AudioClip clip, float volume){
        _audioSource.PlayOneShot(clip, volume);
    }

	void OnDestroy()
	{
		OnEncounterStart -= SwitchToEncounter;
        OnEncounterEnd -= SwitchToMain;
	}
}
