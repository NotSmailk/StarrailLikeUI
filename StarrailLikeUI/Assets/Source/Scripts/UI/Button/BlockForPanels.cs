using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BlockForPanels : MonoBehaviour, IPointerClickHandler
{
    private UnityEvent _onClick = new UnityEvent();

    public void Add(UnityAction action)
    {
        _onClick.AddListener(action);
    }

    public void RemoveAll()
    {
        _onClick.RemoveAllListeners();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _onClick.Invoke();
    }
}
