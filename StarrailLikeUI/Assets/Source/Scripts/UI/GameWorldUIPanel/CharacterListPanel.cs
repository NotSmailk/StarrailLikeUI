using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterListPanel : MonoBehaviour
{
    [field: SerializeField] private CharacterIconView _iconPrefab;

    [Inject] private GameCharacters _gameCharacters;

    private List<CharacterIconView> _icons = new List<CharacterIconView>();
    private CharacterIconView _activeIcon;

    public void Init(SquadData squad)
    {
        foreach (var item in squad.Squad)
        {
            var icon = Instantiate(_iconPrefab, transform);
            icon.Init(item, squad.Squad.IndexOf(item) + 1);
            _icons.Add(icon);
        }

        SetActiveIcon(_gameCharacters.CurIndex);
    }

    public void SetActiveIcon(int id)
    {
        if (id < 0 || id >= _icons.Count)
            return;

        if (_icons.IndexOf(_activeIcon).Equals(id)) 
            return;

        foreach (var i in _icons)
        {
            i.ActiveIcon(false);
        }

        _activeIcon = _icons[id];
        _icons[id].ActiveIcon(true);
    }
}
