using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AssignmentPanel : VerticalScrollablePanel
{
    [field: Header("Panel Parametres")]
    [field: SerializeField] private TextMeshProUGUI _assignmentName;
    [field: SerializeField] private TextMeshProUGUI _assignmentDescription;
    [field: SerializeField] private Image _itemSprite;
    [field: SerializeField] private AnimatedButtonBorders _recalButton;
    [field: SerializeField] private AnimatedButtonBorders _dispatchButton;
    [field: SerializeField] private AnimatedButtonBorders _itemShowButton;

    [Inject] private GameStateMachine _machine;
    [Inject] private ItemCollectionProvider _itemCollectionProvider;

    public void Init(Assignment data)
    {
        _assignmentName.text = data.Name;
        _assignmentDescription.text = data.Description;
        _itemSprite.sprite = _itemCollectionProvider.GetItem(data.ItemId).Sprite;
        _itemShowButton.Add(() => { ItemShow(data.ItemId); });
    }

    public void ItemShow(int id)
    {
        _itemCollectionProvider.ItemToShowId = id;
        _machine.SwitchStateWithoutExit<GameItemViewMenuState>();
    }
}
