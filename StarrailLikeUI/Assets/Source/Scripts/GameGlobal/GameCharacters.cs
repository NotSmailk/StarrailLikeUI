using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCharacters : MonoBehaviour
{
    private List<Player> _characters = new List<Player>();
    private Player _curCharacter;

    [Inject] private SquadData _squadData;

    public Player CurCharacter => _curCharacter;
    public int CurIndex => _characters.IndexOf(_curCharacter);

    public void Init()
    {
        foreach (var character in _squadData.Squad)
        {
            var player = Instantiate(character.CharacterPrefab, transform);
            _characters.Add(player);
            player.gameObject.SetActive(false);
        }

        SetActiveCharater(0);
    }

    public void SetActiveCharater(int id)
    {
        if (id < 0 || id >= _characters.Count)
            return;

        if (_characters.IndexOf(_curCharacter).Equals(id))
            return;

        _curCharacter?.gameObject.SetActive(false);
        _curCharacter = _characters[id];
        _curCharacter.gameObject.SetActive(true);
        _curCharacter.EnterWorldMode();
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
