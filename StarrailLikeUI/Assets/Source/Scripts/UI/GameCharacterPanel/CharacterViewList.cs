using UnityEngine;

public class CharacterViewList : MonoBehaviour
{
    [field: SerializeField] private CharacterSelectButton _buttonPrefab;

    public void Init(UnityEngine.Events.UnityAction<int> chooseCharacter, SquadData squad)
    {
        foreach (var item in squad.Squad)
        {
            var icon = Instantiate(_buttonPrefab, transform);
            icon.Init(chooseCharacter, squad.Squad.IndexOf(item), item.CharacterAvatar);
        }
    }
}
