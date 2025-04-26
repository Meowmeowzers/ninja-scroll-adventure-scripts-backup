using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMPro.TMP_Dropdown dropdown;
    
    private const string MUSIC_KEY = "MusicVolume";
    private const string SFX_KEY = "SFXVolume";
    private const string FPS_KEY = "Graphics_FPS";

	void Start()
	{
        musicSlider.onValueChanged.AddListener(GameManager.instance.GetComponent<AudioSettings>().SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(GameManager.instance.GetComponent<AudioSettings>().SetSFXVolume);
        dropdown.onValueChanged.AddListener(GameManager.instance.GetComponent<GraphicsSettings>().ApplyFPS);
	}

    public void InitializeSettingsUI(){
        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat(SFX_KEY, 0.5f);
        dropdown.value = PlayerPrefs.GetInt(FPS_KEY, 1);
    }

	void OnDisable()
	{
		musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
        dropdown.onValueChanged.RemoveAllListeners();
	}
}
