using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    IInteractable _interactable;
    [SerializeField] bool _hasInteractable = false;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponent<IInteractable>() != null){
            _interactable = collision.GetComponent<IInteractable>();
            _hasInteractable = true;
        }
	}

	void OnTriggerExit2D(Collider2D other)
	{
		_interactable = null;
        _hasInteractable = false;
	}

    public void Interact(){
        if(_interactable != null){
            _interactable.Interact();
            Debug.Log("interact");
            return;
        }
        Debug.Log("none");
    }
}
