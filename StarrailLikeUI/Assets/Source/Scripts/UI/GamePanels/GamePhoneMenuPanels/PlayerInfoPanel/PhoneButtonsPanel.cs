using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PhoneButtonsPanel : MonoBehaviour
{
    [field: SerializeField] private Button _storeBtn;
    [field: SerializeField] private Button _friendsBtn;
    [field: SerializeField] private Button _assignmentsBtn;
    [field: SerializeField] private Button _charactersBtn;
    [field: SerializeField] private Button _spinBtn;
    [field: SerializeField] private Button _inventoryBtn;

    [Inject] private GameStateMachine _gameBehaviour;

    private List<Button> _buttons = new List<Button>();

    public void Init()
    {
        _storeBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameStoreMenuState>);
        _friendsBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameFriendsMenuState>);
        _assignmentsBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameAssignementsMenuState>);
        _spinBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameSpinsMenuState>);
        _inventoryBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameInventoryState>);
        _charactersBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameCharactersMenuState>);

        _buttons.Add(_storeBtn);
        _buttons.Add(_friendsBtn);
        _buttons.Add(_assignmentsBtn);
        _buttons.Add(_spinBtn);
        _buttons.Add(_inventoryBtn);
        _buttons.Add(_charactersBtn);
    }

    public void Interactble(bool active)
    {
        foreach (var btn in _buttons)
        {
            if (btn.TryGetComponent(out Image image))
                image.raycastTarget = active;
        }
    }
}
