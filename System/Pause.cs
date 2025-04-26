using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	void Awake()
	{
		Time.timeScale = 1f;
	}

	public static void PauseGame(){
        if(Time.timeScale == 1f){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
    }

    public static bool IsGamePaused(){
        return Time.timeScale == 0f ? true : false;
    }
}
