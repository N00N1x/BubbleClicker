using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource _sfxBubble;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Singleton.OnClick();

        _sfxBubble.Play();
    }
}
