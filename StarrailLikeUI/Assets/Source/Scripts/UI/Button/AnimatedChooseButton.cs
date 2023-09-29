using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AnimatedChooseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public abstract void OnPointerDown(PointerEventData eventData);
    public abstract void OnPointerEnter(PointerEventData eventData);

    public abstract void OnPointerExit(PointerEventData eventData);
    public abstract void OnPointerUp(PointerEventData eventData);
}
