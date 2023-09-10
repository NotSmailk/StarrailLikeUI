using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatedButtonBorders : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [field: Header("Animation Parametres")]
    [field: SerializeField] private AnimatedButtonType _buttonType = AnimatedButtonType.Size;
    [field: SerializeField] private RectTransform _rect;
    [field: SerializeField] private Image _image;
    [field: SerializeField] private float enterSizeCoef = 0.1f;
    [field: SerializeField] private float clickSizeCoef = 0.15f;
    [field: SerializeField] private Color enterColor = Color.gray;
    [field: SerializeField] private Color clickColor = Color.gray;

    private Color defaultColor;
    private Vector2 defaultSize;

    private void Awake()
    {
        defaultSize = _rect.sizeDelta;
        defaultColor = _image.color;
    }

    public async void OnPointerClick(PointerEventData eventData)
    {
        _image.maskable = false;
        var size = defaultSize * (1 + clickSizeCoef);

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                DOTween.Sequence().
                    Append(_rect.DOSizeDelta(size, 0.05f)).
                    Append(_rect.DOSizeDelta(defaultSize, 0.05f));
                break;
            case AnimatedButtonType.Color:
                DOTween.Sequence().
                    Append(_image.DOColor(clickColor, 0.05f)).
                    Append(_image.DOColor(defaultColor, 0.05f));
                break;
            case AnimatedButtonType.ColorAndSize:
                DOTween.Sequence().
                    Append(_rect.DOSizeDelta(size, 0.05f)).
                    Append(_rect.DOSizeDelta(defaultSize, 0.05f));
                DOTween.Sequence().
                    Append(_image.DOColor(clickColor, 0.05f)).
                    Append(_image.DOColor(defaultColor, 0.05f));
                break;
        }

        await Task.Delay(100);
        _image.maskable = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.maskable = false;
        var size = _rect.sizeDelta * (1 + enterSizeCoef);

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                _rect.DOSizeDelta(size, 0.1f);
                break;
            case AnimatedButtonType.Color:
                _image.DOColor(enterColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                _rect.DOSizeDelta(size, 0.1f);
                _image.DOColor(enterColor, 0.1f);
                break;
        }
    }

    public async void OnPointerExit(PointerEventData eventData)
    {
        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                _rect.DOSizeDelta(defaultSize, 0.1f);
                break;
            case AnimatedButtonType.Color:
                _image.DOColor(defaultColor, 0.1f);
                break;
            case AnimatedButtonType.ColorAndSize:
                _rect.DOSizeDelta(defaultSize, 0.1f);
                _image.DOColor(defaultColor, 0.1f);
                break;
        }
        await Task.Delay(100);
        _image.maskable = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.maskable = false;
        var size = defaultSize * (1 + clickSizeCoef);

        switch (_buttonType)
        {
            case AnimatedButtonType.Size:
                _rect.DOSizeDelta(size, 0.05f);
                break;
            case AnimatedButtonType.Color:
                _image.DOColor(clickColor, 0.05f);
                break;
            case AnimatedButtonType.ColorAndSize:
                _rect.DOSizeDelta(size, 0.05f);
                _image.DOColor(clickColor, 0.05f);
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerExit(eventData);
    }
}
