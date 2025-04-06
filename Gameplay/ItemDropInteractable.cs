using UnityEngine;

public class ItemDropInteract : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject itemToDrop;
    [SerializeField] Sprite openedSprite;
    [SerializeField] bool isOpened = false;
    SpriteRenderer sr;

    void Awake(){
        sr = GetComponent<SpriteRenderer>();
    }

    public void Interact(){
        if(!isOpened){
            sr.sprite = openedSprite;
            Instantiate(itemToDrop, transform.position + new Vector3(0,-1,0), Quaternion.identity);
        }
    }

}
