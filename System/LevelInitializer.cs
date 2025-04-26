using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] PlayerStats _player;
    [SerializeField] InGameUI _ingameUI;
    [SerializeField] Collection _collection;

	public void InitializeLevel(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.name == "MainMenuScene") return;
        
        _collection = GameManager.instance.collection;
        _ingameUI = GameManager.instance.inGameUI;
        _player = FindObjectOfType<PlayerStats>();

        if (_ingameUI != null && _player != null && _collection != null){
            GameManager.instance.collection.ResetCollection();
            _ingameUI.ReconnectStatsToUI(_player, _collection);
        }

        GameManager.instance.gameTimer.StartTimer();
        GameManager.instance.audioPlayer.SwitchToMainMusic();
    }
}
