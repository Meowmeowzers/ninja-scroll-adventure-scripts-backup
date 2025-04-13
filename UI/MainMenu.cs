using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _optionsMenu;

    public void OpenStartMenu(){
        _startMenu.SetActive(true);
        _optionsMenu.SetActive(false);
	}
    public void OpenOptionsMenu(){
        _optionsMenu.SetActive(true);
        _startMenu.SetActive(false);
	}

    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }
}
