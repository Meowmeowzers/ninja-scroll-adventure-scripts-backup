using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SFXVolume";

	public void InitializeAudioSettings()
	{
        audioMixer.SetFloat(MUSIC_KEY, PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f));
		audioMixer.SetFloat(SFX_KEY, PlayerPrefs.GetFloat(SFX_KEY, 0.5f));
	}
    
	public void SetMusicVolume(float volume)
    {
        float normalizedVolume = Mathf.Clamp(volume / 100f, 0.0001f, 1f);
        float dB = Mathf.Log10(normalizedVolume) * 20;

        audioMixer.SetFloat(MUSIC_KEY, dB);
        PlayerPrefs.SetFloat(MUSIC_KEY, volume);
    }

    public void SetSFXVolume(float volume)
    {
        float normalizedVolume = Mathf.Clamp(volume / 100f, 0.0001f, 1f);
        float dB = Mathf.Log10(normalizedVolume) * 20;
        
        audioMixer.SetFloat(SFX_KEY, dB);
        PlayerPrefs.SetFloat(SFX_KEY, volume);
    }

    public void ResetAudioSettings()
    {
        PlayerPrefs.SetFloat(MUSIC_KEY, 0.5f);
        PlayerPrefs.SetFloat(SFX_KEY, 0.5f);
    }
}
