using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [field: SerializeField] private AnimatedButtonType _buttonType = AnimatedButtonType.Size;
    [field: SerializeField] private float enterSizeCoef = 0.1f;
    [field: SerializeField] private float clickSizeCoef = 0.15f;
    [field: SerializeField] private Color enterColor = Color.gray;
    [field: SerializeField] private Color clickColor = Color.gray;

    private Color defaultColor;
    private Vector2 defaultSize;
    private RectTransform rect;
    private Image image;
    private UnityEvent _onClick = new UnityEvent();

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        defaultSize = rect.sizeDelta;

        image = GetComponent<Image>();
        defaultColor = image.color;
    }

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
        var size = defaultSize * (1 + clickSizeCoef);
        _onClick.Invoke();

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                DOTween.Sequence().
                    Append(rect.DOSizeDelta(size, 0.05f)).
                    Append(rect.DOSizeDelta(defaultSize, 0.05f));
                break;
            case AnimatedButtonType.Color:
                DOTween.Sequence().
                    Append(image.DOColor(clickColor, 0.05f)).
                    Append(image.DOColor(defaultColor, 0.05f));
                break;
            case AnimatedButtonType.ColorAndSize:
                DOTween.Sequence().
                    Append(rect.DOSizeDelta(size, 0.05f)).
                    Append(rect.DOSizeDelta(defaultSize, 0.05f));
                DOTween.Sequence().
                    Append(image.DOColor(clickColor, 0.05f)).
                    Append(image.DOColor(defaultColor, 0.05f));
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        var size = rect.sizeDelta * (1 + enterSizeCoef);

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                rect.DOSizeDelta(size, 0.1f);
                break;
            case AnimatedButtonType.Color:
                image.DOColor(enterColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                rect.DOSizeDelta(size, 0.1f);
                image.DOColor(enterColor, 0.1f);
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                rect.DOSizeDelta(defaultSize, 0.1f);
                break;
            case AnimatedButtonType.Color:
                image.DOColor(defaultColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                rect.DOSizeDelta(defaultSize, 0.1f);
                image.DOColor(defaultColor, 0.1f);
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerEnter(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);
    }
}
