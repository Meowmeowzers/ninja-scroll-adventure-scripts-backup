using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject optionsMenu;
    void Start()
    {
        
    }
    public void OpenStartMenu(){
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
		// optionsMenu.GetComponent<Canvas>().enabled = false;
		// startMenu.GetComponent<Canvas>().enabled = true;
	}
    public void OpenOptionsMenu(){
        optionsMenu.SetActive(true);
        startMenu.SetActive(false);
		// startMenu.GetComponent<Canvas>().enabled = false;
		// optionsMenu.GetComponent<Canvas>().enabled = true;
	}

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
