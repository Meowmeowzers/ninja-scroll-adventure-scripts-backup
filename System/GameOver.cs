using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] GameObject _elements;
    [SerializeField] AudioClip _gameOverMusic;
    
    public void ShowGameOver()
    {
        GameManager.instance.audioPlayer.PlayMusic(_gameOverMusic);
        StartCoroutine(GameOverRoutine());
        StartCoroutine(BlackScreenRoutine());
    }
    
    IEnumerator BlackScreenRoutine(){
        yield return new WaitForSecondsRealtime(3f);
        float x = 0f;

        while(x <= 1f){
            _image.color = new Color(0,0,0,x);
            x += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    IEnumerator GameOverRoutine(){
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 0f;
        _elements.SetActive(true);
    }

    public void RestartLevel()
    {
        StopAllCoroutines();
        GetComponent<Canvas>().enabled = false;
        _image.color = new Color(0,0,0,0);
        _elements.SetActive(false);
        GameManager.instance.StartGame();

    }

    public void ReturnToMenu()
    {
        StopAllCoroutines();
        GetComponent<Canvas>().enabled = false;
        _image.color = new Color(0,0,0,0);
        _elements.SetActive(false);
        GameManager.instance.BackToMenu();
    }
}
