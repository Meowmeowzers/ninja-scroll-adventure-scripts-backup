using UnityEngine;

public class UIButton : MonoBehaviour
{ 
    [SerializeField] private GameObject _open;
    [SerializeField] private GameObject _close;
    
	void OpenWindow(){
		_open.SetActive(true);
		gameObject.SetActive(false);
	}

}
