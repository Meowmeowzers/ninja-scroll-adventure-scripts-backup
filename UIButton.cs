using UnityEngine;

public class UIButton : MonoBehaviour
{ 
    [SerializeField] GameObject open;
    [SerializeField] GameObject close;
    
	void OpenWindow(){
		open.SetActive(true);
		gameObject.SetActive(false);
	}

}
