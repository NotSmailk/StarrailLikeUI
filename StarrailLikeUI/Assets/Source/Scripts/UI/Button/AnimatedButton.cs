using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [field: SerializeField] protected AnimatedButtonType _buttonType = AnimatedButtonType.Size;
    [field: SerializeField] protected float enterSizeCoef = 0.1f;
    [field: SerializeField] protected float clickSizeCoef = 0.15f;
    [field: SerializeField] protected Color enterColor = Color.gray;
    [field: SerializeField] protected Color clickColor = Color.gray;

    protected Color defaultColor;
    protected Vector2 defaultSize;
    private RectTransform rect;
    private Image image;
    protected UnityEvent _onClick = new UnityEvent();

    [Inject] protected GameUI _ui;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        defaultSize = rect.sizeDelta;

        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    public virtual void Add(UnityAction action)
    {
        _onClick.AddListener(action);
    }

    public virtual void RemoveAll()
    {
        _onClick.RemoveAllListeners();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (!image.raycastTarget)
            return;

        var size = rect.sizeDelta * (1 + enterSizeCoef);
        _ui.PlayHover();

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

    public virtual void OnPointerExit(PointerEventData eventData)
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

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        var size = defaultSize * (1 + clickSizeCoef);
        _onClick.Invoke();
        _ui.PlayClick();

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                rect.DOSizeDelta(size, 0.1f);
                break;
            case AnimatedButtonType.Color:
                image.DOColor(clickColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                rect.DOSizeDelta(size, 0.1f);
                image.DOColor(clickColor, 0.1f);
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
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
}
