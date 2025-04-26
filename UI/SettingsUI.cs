using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMPro.TMP_Dropdown dropdown;

	void Start()
	{
        musicSlider.onValueChanged.AddListener(GameManager.instance.GetComponent<AudioSettings>().SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(GameManager.instance.GetComponent<AudioSettings>().SetSFXVolume);
        dropdown.onValueChanged.AddListener(GameManager.instance.GetComponent<GraphicsSettings>().ApplyFPS);
	}

    public void InitializeSettingsUI(){
        musicSlider.value = PlayerPrefs.GetFloat(Constants.MUSIC_KEY, Constants.VOLUME_DEFAULT);
        sfxSlider.value = PlayerPrefs.GetFloat(Constants.SFX_KEY, Constants.VOLUME_DEFAULT);
        dropdown.value = PlayerPrefs.GetInt(Constants.FPS_KEY, Constants.FPS_DEFAULT);
    }

	void OnDisable()
	{
		musicSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
        dropdown.onValueChanged.RemoveAllListeners();
	}
}
