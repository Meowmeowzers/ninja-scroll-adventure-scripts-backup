using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameState _gameState = GameState.MainMenu;
    [SerializeField] Canvas _ingame;
    [SerializeField] Canvas _options;
    [SerializeField] Canvas _pause;
    [SerializeField] Canvas _startMenu;
    [SerializeField] Canvas _optionsMenu;
    [SerializeField] Canvas _creditsMenu;
    [SerializeField] Canvas _gameOverUI;
    [SerializeField] Canvas _winScreen;
    [SerializeField] Canvas _tutorialScreen;
    public AudioPlayer audioPlayer;
    public AudioSettings audioSettings;
    public Collection collection;
    public GameTimer gameTimer;
    public GraphicsSettings graphicsSettings;
    public InGameUI inGameUI;
    LevelInitializer _levelInitializer;

    void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        audioPlayer = GetComponentInChildren<AudioPlayer>();
        audioSettings = GetComponent<AudioSettings>();
        collection = GetComponent<Collection>();
        gameTimer = GetComponent<GameTimer>();
        graphicsSettings = GetComponent<GraphicsSettings>();
        inGameUI = GetComponentInChildren<InGameUI>();
        _levelInitializer = GetComponent<LevelInitializer>();
    }

    void OnEnable()
    {
        if(_levelInitializer != null)
            SceneManager.sceneLoaded += _levelInitializer.InitializeLevel;
            audioSettings.InitializeAudioSettings();
    }

    void OnDisable()
    {
        if(_levelInitializer != null)
            SceneManager.sceneLoaded -= _levelInitializer.InitializeLevel;
    }

    public void PauseGame(){
        if(Time.timeScale == 0f){
            _pause.enabled = true;
            _ingame.enabled = false;
        }
        else{
            _pause.enabled = false;
            _options.enabled = false;
            _ingame.enabled = true;
        }
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        _pause.enabled = false;
        _options.enabled = false;
        _ingame.enabled = true;
        GetComponent<AudioSettings>().AllowVolumeChange(false);
    }

    public void ShowOptionsScreen(){
        _pause.enabled = false;
        _options.enabled = true;
        _options.GetComponent<SettingsUI>().InitializeSettingsUI();
        GetComponent<AudioSettings>().AllowVolumeChange(true);
    }

    public void ShowPauseScreen(){
        _pause.enabled = true;
        _options.enabled = false;
        GetComponent<AudioSettings>().AllowVolumeChange(false);
    }

    public void StartGame(){
        _startMenu.enabled = false;
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        audioPlayer.SwitchToMainMusic();
        _ingame.enabled = true;
        GetComponent<AudioSettings>().AllowVolumeChange(false);
    }
    public void OpenStartMenu(){
        _startMenu.enabled = true;
        _optionsMenu.enabled = false;
        _creditsMenu.enabled = false;
        GetComponent<AudioSettings>().AllowVolumeChange(false);
	}
    public void OpenOptionsMenu(){
        _optionsMenu.enabled = true;
        _startMenu.enabled = false;
        _optionsMenu.GetComponent<SettingsUI>().InitializeSettingsUI();
        GetComponent<AudioSettings>().AllowVolumeChange(true);
	}
    public void BackToMenu(){
        _ingame.enabled = false;
        _pause.enabled = false;
        _options.enabled = false;
        _gameOverUI.enabled = false;
        _winScreen.GetComponent<WinUI>().Reset();
        _winScreen.enabled = false;
        GetComponent<AudioSettings>().AllowVolumeChange(false);
        Time.timeScale = 1f;
        audioPlayer.SwitchToTitleMusic();
        SceneManager.LoadScene("MainMenuScene");
        _startMenu.enabled = true;
    }

    public void OpenCreditsMenu(){
        _creditsMenu.enabled = true;
        _startMenu.enabled = false;
    }

    public void GameOver(){
        _gameState = GameState.GameOver;
        _gameOverUI.enabled = true;
        _gameOverUI.GetComponent<GameOver>().ShowGameOver();
    }

    public void WinGame(){
        _ingame.enabled = false;
        _winScreen.enabled = true;
        FindObjectOfType<PlayerController>().EnableControl(false);
        FindObjectOfType<PlayerController>().GetComponent<Movement>().StopMove();
        gameTimer.StopTimer();
        _winScreen.GetComponent<WinUI>().StartWin();
    }
    public void ShowTutorialScreen(int value){
        _tutorialScreen.enabled = true;

        if(value == 0)
            _tutorialScreen.GetComponent<TutorialUI>().ShowMove();
        else if(value == 1)
            _tutorialScreen.GetComponent<TutorialUI>().ShowAttack();
        else if(value == 2)
            _tutorialScreen.GetComponent<TutorialUI>().ShowScrolls();
        else if(value == 3)
            _tutorialScreen.GetComponent<TutorialUI>().ShowEnemies();
        else{
            _tutorialScreen.GetComponent<TutorialUI>().HideTutorialScreen();
            _tutorialScreen.enabled = false;
        }
    }

    public GameState GetState() => _gameState;
}
