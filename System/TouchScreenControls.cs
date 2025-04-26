using UnityEngine;

public class TouchScreenControls : MonoBehaviour
{
    [SerializeField] private GameObject touchControlsParent;

    void Start()
    {
        InputMode mode = DetectOrLoadInputMode();
        touchControlsParent.SetActive(mode == InputMode.Touch);
    }

    InputMode DetectOrLoadInputMode()
    {
        if (PlayerPrefs.HasKey("InputMode"))
            return (InputMode)PlayerPrefs.GetInt("InputMode");

        InputMode mode = WebGLPlatform.IsMobileDevice() ? InputMode.Touch : InputMode.Keyboard;
        PlayerPrefs.SetInt("InputMode", (int)mode);
        return mode;
    }

    public void SetInputMode(int modeIndex) // 0 = Keyboard, 1 = Touch
    {
        PlayerPrefs.SetInt("InputMode", modeIndex);
        touchControlsParent.SetActive(modeIndex == 1);
    }
}
