using UnityEngine;
using Zenject;

public class CharacterViewChooseList : MonoBehaviour
{
    [field: SerializeField] private CharacterSelectButton _buttonPrefab;

    [Inject] private CharactersDataProvider _charactersDataProvider;

    public void Init(UnityEngine.Events.UnityAction<int> chooseCharacter, SquadData squad)
    {
        foreach (var item in squad.Squad)
        {
            var character = _charactersDataProvider.GetCharacter(item);
            var icon = Instantiate(_buttonPrefab, transform);
            icon.Init(chooseCharacter, squad.Squad.IndexOf(item), character.Avatar);
        }
    }
}
