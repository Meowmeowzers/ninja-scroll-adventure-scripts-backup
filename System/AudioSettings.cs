using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    bool allowVolumeChange = false;

	public void InitializeAudioSettings()
	{        
        audioMixer.SetFloat(Constants.MUSIC_KEY, PlayerPrefs.GetFloat(Constants.MUSIC_KEY, Constants.VOLUME_DEFAULT));
		audioMixer.SetFloat(Constants.SFX_KEY, PlayerPrefs.GetFloat(Constants.SFX_KEY, Constants.VOLUME_DEFAULT));
	}
    
	public void SetMusicVolume(float volume)
    {
        if(!allowVolumeChange) return;
        
        audioMixer.SetFloat(Constants.MUSIC_KEY, VolumeToDecibel(volume));
        PlayerPrefs.SetFloat(Constants.MUSIC_KEY, volume);
    }

    public void SetSFXVolume(float volume)
    {
        if(!allowVolumeChange) return;
        
        audioMixer.SetFloat(Constants.SFX_KEY, VolumeToDecibel(volume));
        PlayerPrefs.SetFloat(Constants.SFX_KEY, volume);
    }

    public void ResetAudioSettings(){
        PlayerPrefs.SetFloat(Constants.MUSIC_KEY, Constants.VOLUME_DEFAULT);
        PlayerPrefs.SetFloat(Constants.SFX_KEY, Constants.VOLUME_DEFAULT);
    }

    float VolumeToDecibel(float volume){
        float normalized = Mathf.Clamp(volume, 0.0001f, 1f);
        return Mathf.Log10(normalized) * 20;
    }

    public void AllowVolumeChange(bool value){
        allowVolumeChange = value;
    }
}
