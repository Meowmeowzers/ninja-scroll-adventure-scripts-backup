using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    private readonly int[] fpsOptions = { 30, 60, -1 };
 
    private void Start()
    {   
        // bool isFullscreen = PlayerPrefs.GetInt(Constants.FULLSCREEN_KEY, 0) == 1;
        // fullscreenToggle.isOn = isFullscreen;
        // ApplyFullscreen(isFullscreen);

        GameManager.instance.graphicsSettings.ApplyFPS(PlayerPrefs.GetInt(Constants.FPS_KEY, Constants.FPS_DEFAULT));
    }

    public void ApplyFPS(int value)
    {
        Application.targetFrameRate = fpsOptions[value];
        PlayerPrefs.SetInt(Constants.FPS_KEY, value);
    }

    public void ApplyFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt(Constants.FULLSCREEN_KEY, isFullscreen ? 1 : 0);
    }
}
