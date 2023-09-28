using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCharacters : MonoBehaviour
{
    private List<Player> _characters = new List<Player>();
    private Player _curCharacter;

    [Inject] private SquadData _squadData;
    [Inject] private CharactersDataProvider _provider;

    public Player CurCharacter => _curCharacter;
    public int CurIndex => _characters.IndexOf(_curCharacter);

    public void Init()
    {
        foreach (var id in _squadData.Squad)
        {
            var character = _provider.GetCharacter(id);
            var player = Instantiate(character.Prefab, transform);
            _characters.Add(player);
            player.gameObject.SetActive(false);
        }

        SetActiveCharater(0);
    }

    public bool SetActiveCharater(int id)
    {
        if (id < 0 || id >= _characters.Count)
            return false;

        if (_characters.IndexOf(_curCharacter).Equals(id))
            return false;

        _curCharacter?.gameObject.SetActive(false);
        _curCharacter = _characters[id];
        _curCharacter.gameObject.SetActive(true);
        _curCharacter.EnterWorldMode();

        return true;
    }

    public void ActivatePhoneMode()
    {
        _curCharacter.EnterPhoneMode();
    }

    public void ActivateWorldMode()
    {
        _curCharacter.EnterWorldMode();
    }
}
