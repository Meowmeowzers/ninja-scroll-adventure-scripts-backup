using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip _mainMusic;
    [SerializeField] AudioClip _encounterMusic;
    [SerializeField] AudioClip _bossMusic;
    [SerializeField] AudioClip _winMusic;
    [SerializeField] AudioClip _titleMusic;
    [SerializeField] AudioClip _creditsMusic;

    [SerializeField] AudioSource _sfxSource;
    [SerializeField] AudioSource _musicSource;
	float _timeMain;
    float _timeEncounter;
    
	void Start()
	{
        // using the initialize function makes volume broken
        GameManager.instance.audioSettings.SetMusicVolume(PlayerPrefs.GetFloat(Constants.MUSIC_KEY, Constants.VOLUME_DEFAULT));
        GameManager.instance.audioSettings.SetSFXVolume(PlayerPrefs.GetFloat(Constants.SFX_KEY, Constants.VOLUME_DEFAULT)); 
		_musicSource.clip = _titleMusic;
        _musicSource.Play();
	}

    public void SwitchToMainMusic(){
        _timeEncounter = _musicSource.time;
        _musicSource.clip = _mainMusic;
        _musicSource.time = _timeMain;
        _musicSource.Play();
    }
	public void SwitchToEncounterMusic(){
        _timeMain = _musicSource.time;
        _musicSource.clip = _encounterMusic;
        _musicSource.time = _timeEncounter;
        _musicSource.Play();
    }

    public void SwitchToTitleMusic(){
        PlayMusic(_titleMusic);
    }
    public void SwitchToCreditsMusic(){
        PlayMusic(_creditsMusic);
    }
    public void SwitchToBossMusic(){
        PlayMusic(_bossMusic);
    }
    public void SwitchToWinMusic(){
        PlayMusic(_winMusic);
    }
    
    public void PlayMusic(AudioClip clip, float volume = 1f){
        _musicSource.time = 0f;
        _musicSource.clip = clip;
        _musicSource.Play();
    }
	public void PlaySound(AudioClip clip, float volume = 1f){
		_sfxSource.PlayOneShot(clip, volume);
	}

}
