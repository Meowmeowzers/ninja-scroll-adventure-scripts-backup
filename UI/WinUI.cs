using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] GameObject _message;
    [SerializeField] TextMeshProUGUI _messageText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject _score;
    [SerializeField] GameObject _credits;

	public void StartWin()
	{
        StartCoroutine(GameOverRoutine());
    }
    
    IEnumerator GameOverRoutine(){
        yield return new WaitForSecondsRealtime(3f);

        GameManager.instance.audioPlayer.SwitchToWinMusic();

        float x = 0f;

        while(x <= 1f){
            _image.color = new Color(0,0,0,x);
            x += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        int collected = GameManager.instance.collection.GetScore();
        string time = GameManager.instance.gameTimer.GetFormattedTime();

        _messageText.text = GetWinMessage(collected, 20); // 20 currently magic number, based on existing scrolls on scene
        _scoreText.text = $"Time Taken:\n{time}\nScrolls Collected:\n{collected} / 20";
        _message.SetActive(true);

    }

    public void Reset(){
        _image.color = new Color(0, 0, 0, 0);
        _message.SetActive(false);
        _score.SetActive(false);
        _credits.SetActive(false);
        enabled = false;
    }
    
    public void NextScreen(int value){
        switch(value){
            case 0:
                    _message.SetActive(false);
                    _score.SetActive(true);
                break;
            case 1:
                    _score.SetActive(false);
                    _credits.SetActive(true);
                break;
            default:
                return;
        }
    }

    string GetWinMessage(int collectedScrolls, int totalScrolls){
        float ratio = (float)collectedScrolls / totalScrolls;

        if(ratio == 1f)
            return "The sacred scrolls are safe.\nThe path of the ninja endures.";
        else if(ratio >= 0.5f)
            return "Most scrolls were recovered.\nThe path is nearly whole, but some secrets remain in darkness.";
        else if(ratio >= 0.25f)
            return "You fought well, but many scrolls are still missing.\nA partial victory carved in silence.";
        else if(ratio > 0f)
            return "A hollow victory. Few scrolls were found.\nThe whispers of the past grow faint.";
        else
            return "Victory came at a cost.\nNot a single scroll was recovered.";
    }

}
