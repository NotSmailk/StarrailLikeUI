using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CharacterViewChooseList : MonoBehaviour
{
    [field: SerializeField] private CharacterSelectButton _buttonPrefab;

    [Inject] private CharactersDataProvider _charactersDataProvider;

    private Dictionary<int, CharacterSelectButton> _buttons = new Dictionary<int, CharacterSelectButton>();
    private CharacterSelectButton _selectedButton;
    private UnityEvent<int> _onChoose = new UnityEvent<int>();

    public void Init(UnityAction<int> chooseCharacter, SquadData squad)
    {
        foreach (var item in squad.Squad)
        {
            _onChoose.AddListener(chooseCharacter);
            var character = _charactersDataProvider.GetCharacter(item);
            var icon = Instantiate(_buttonPrefab, transform);
            _buttons.Add(squad.Squad.IndexOf(item), icon);
            icon.Init(ChooseCharacter, squad.Squad.IndexOf(item), character.Avatar);
        }

        ChooseCharacter(0);
    }

    public void ChooseCharacter(int id)
    {
        if (_buttons.TryGetValue(id, out CharacterSelectButton button))
        {
            if (button.Equals(_selectedButton))
                return;

            _selectedButton?.Deselect();
            _selectedButton = button;
            _selectedButton.Select();
            _onChoose.Invoke(id);
        }
    }
}
