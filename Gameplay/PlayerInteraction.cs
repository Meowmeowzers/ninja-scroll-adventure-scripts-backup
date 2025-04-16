using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    IInteractable _interactable;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<IInteractable>() != null){
            _interactable = collision.GetComponent<IInteractable>();
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		_interactable = null;
	}

    public void Interact(){
        if(_interactable != null){
            _interactable.Interact();
            Debug.Log("interact");
        }
    }
}
