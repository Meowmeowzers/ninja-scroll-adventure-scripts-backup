using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour
{
    [SerializeField] int screen = 0;
    bool _isShown = true;

	void OnTriggerStay2D(Collider2D collision)
	{
        if(_isShown && collision.CompareTag("Player")){
            GameManager.instance.ShowTutorialScreen(screen);
        }
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Player")){
                GameManager.instance.ShowTutorialScreen(screen);            
        }
	}
	void OnTriggerExit2D(Collider2D collision)
	{
        _isShown = false;
        if(collision.CompareTag("Player")){
                GameManager.instance.ShowTutorialScreen(10);            
        }
	}
}
