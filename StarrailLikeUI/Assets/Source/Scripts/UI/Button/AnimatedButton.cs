using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using static Zenject.CheatSheet;

public class AnimatedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
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
    protected bool _clicked = false;

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

    public virtual void OnPointerClick(PointerEventData eventData)
    {        
        var size = defaultSize * (1 + clickSizeCoef);
        _onClick.Invoke();

        if (_clicked)
        {
            _clicked = false;
        }
        else
        {
            _ui.PlayClick();
            _clicked = true;
        }

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

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerEnter(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);
    }
}
