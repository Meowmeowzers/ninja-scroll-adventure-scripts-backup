using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    private readonly int[] fpsOptions = { 30, 60, -1 };
    private const string FULLSCREEN_KEY = "Graphics_Fullscreen";    
    private const string FPS_KEY = "Graphics_FPS";

    private void Start()
    {   
        // bool isFullscreen = PlayerPrefs.GetInt(FULLSCREEN_KEY, 0) == 1;
        // fullscreenToggle.isOn = isFullscreen;
        // ApplyFullscreen(isFullscreen);

        GameManager.instance.graphicsSettings.ApplyFPS(PlayerPrefs.GetInt(FPS_KEY, 1));
    }

    public void ApplyFPS(int value)
    {
        Application.targetFrameRate = fpsOptions[value];
        PlayerPrefs.SetInt(FPS_KEY, value);
    }

    public void ApplyFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(FULLSCREEN_KEY, isFullscreen ? 1 : 0);
    }
}
