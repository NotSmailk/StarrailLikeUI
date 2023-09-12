using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AnimatedChooseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerClick(eventData);
    }

    public abstract void OnPointerEnter(PointerEventData eventData);

    public abstract void OnPointerExit(PointerEventData eventData);
    public abstract void OnPointerClick(PointerEventData eventData);
}
