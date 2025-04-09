using UnityEngine;

public class ItemDropInteract : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject _itemToDrop;
    [SerializeField] Sprite _openedSprite;
    [SerializeField] bool _isOpened = false;
    SpriteRenderer _sr;

    void Awake(){
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Interact(){
        if(!_isOpened){
            _sr.sprite = _openedSprite;
            Instantiate(_itemToDrop, transform.position + new Vector3(0,-1,0), Quaternion.identity);
        }
    }

}
