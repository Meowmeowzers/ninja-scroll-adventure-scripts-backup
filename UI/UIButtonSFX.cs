using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            GameManager.instance.audioPlayer.PlaySound(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
            GameManager.instance.audioPlayer.PlaySound(clickSound);
    }
}
