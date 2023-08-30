using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [field: SerializeField] private GameWorldPanel _gameWorldPanel;
    [field: SerializeField] private GameMenuPanel _gameMenuPanel;
    [field: SerializeField] private GameStorePanel _gameShopPanel;
    [field: SerializeField] private GameFriendsPanel _gameFriendsPanel;
    [field: SerializeField] private GameAssignmentsPanel _gameAssignmentsPanel;
    [field: SerializeField] private GameInventoryPanel _gameInventoryPanel;
    [field: SerializeField] private GameSpinsMenuPanel _gameSpinsMenuPanel;
    [field: SerializeField] private GameCharactersMenuPanel _gameCharactersMenuPanel;
    [field: SerializeField] private float _switchDuration = 0.3f;

    private Dictionary<Type, IGameMenuPanel> _panels = new Dictionary<Type, IGameMenuPanel>();

    public void Init()
    {
        _panels.Add(typeof(GameWorldPanel), _gameWorldPanel);
        _panels.Add(typeof(GameMenuPanel), _gameMenuPanel);
        _panels.Add(typeof(GameStorePanel), _gameShopPanel);
        _panels.Add(typeof(GameFriendsPanel), _gameFriendsPanel);
        _panels.Add(typeof(GameSpinsMenuPanel), _gameSpinsMenuPanel);
        _panels.Add(typeof(GameAssignmentsPanel), _gameAssignmentsPanel);
        _panels.Add(typeof(GameInventoryPanel), _gameInventoryPanel);
        _panels.Add(typeof(GameCharactersMenuPanel), _gameCharactersMenuPanel);

        foreach (var panel in _panels.Values)
        {
            panel.Init();
            panel.ShowPanelForce(false);
        }        
    }

    public void GameUpdateMenu()
    {
        _gameMenuPanel.GameUpdate();
    }

    public async Task ShowPanel<TGameMenuPanel>(bool show) where TGameMenuPanel : IGameMenuPanel
    {
        if (_panels.TryGetValue(typeof(TGameMenuPanel), out IGameMenuPanel panel))
            await panel.ShowPanel(show, _switchDuration);
    }

    public void SetActiveCharacter(int id)
    {
        _gameWorldPanel.SetActiveCharacter(id);
    }
}
