using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameCharactersMenuPanel : VanishingGamePanel
{
    [field: SerializeField] private CharactersMenuTypeList _charactersMenuTypeList;
    [field: SerializeField] private CharacterViewChooseList _characterViewList;
    [field: SerializeField] private CharactersMenuInfoPanel _charactersMenuInfoPanel;
    [field: SerializeField] private CharactersMenuSkillsPanel _charactersMenuSkillsPanel;
    [field: SerializeField] private Transform _viewpoint;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private SquadData _squadData;
    [Inject] private CharactersDataProvider _provider;

    private List<CharacterUIView> _characters = new List<CharacterUIView>();
    private Dictionary<Type, ICharactersMenuPanel> _panels = new Dictionary<Type, ICharactersMenuPanel>();
    private CharacterUIView _selectedCharacter;
    private ICharactersMenuPanel _curPanel;

    public override void Init()
    {
        InitSubPanels();

        InitMenuTypes();

        InitMainPanel();
    }

    private void InitSubPanels()
    {
        _panels.Add(_charactersMenuInfoPanel.GetType(), _charactersMenuInfoPanel);
        _panels.Add(_charactersMenuSkillsPanel.GetType(), _charactersMenuSkillsPanel);
        foreach (var panel in _panels.Values)
            panel.Show(false);

        _curPanel = _panels[_charactersMenuInfoPanel.GetType()];
        _curPanel.Show(true);
    }

    private void InitMenuTypes()
    {
        _charactersMenuTypeList.Init();
        _charactersMenuTypeList.AddCharacterInfo(() => ShowMenu<CharactersMenuInfoPanel>(true));
        _charactersMenuTypeList.AddCharacterSkills(() => ShowMenu<CharactersMenuSkillsPanel>(true));
    }

    private void InitMainPanel()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        _defaultColor = _panelImg.color;
        _alpha = _defaultColor.a;
        _panelRect.gameObject.SetActive(false);
        _characterViewList.Init(SetActivePlayer, _squadData);
    }

    private void ShowMenu<TCharactersMenu>(bool show) where TCharactersMenu : ICharactersMenuPanel
    {
        if (_panels[typeof(TCharactersMenu)].Equals(_curPanel))
            return;

        _curPanel.Show(false);
        _curPanel = _panels.GetValueOrDefault(typeof(TCharactersMenu));
        _curPanel.Show(show);
    }

    private void SetActivePlayer(int id)
    {
        if (id < 0 || id >= _characters.Count)
            return;

        if (_characters.IndexOf(_selectedCharacter).Equals(id))
            return;

        foreach (var character in _characters)
            character.Show(false);

        _selectedCharacter = _characters[id];
        _charactersMenuInfoPanel.SetActiveCharacter(_selectedCharacter);
        _charactersMenuSkillsPanel.SetActiveCharacter(_selectedCharacter);
        _characters[id].Show(true);
    }

    public override async Task ShowPanel(float duration)
    {
        CreateCharacters();
        await base.ShowPanel(duration);
    }

    private void CreateCharacters()
    {
        foreach (var id in _squadData.Squad)
        {
            var character = _provider.GetCharacter(id);
            var player = Instantiate(character.UIPrefab, _viewpoint);
            player.Init(character.Name, character.Description, character.Skills);
            _characters.Add(player);
        }
        SetActivePlayer(0);
    }

    public override async Task HidePanel(float duration)
    {
        DestroyCharacters();
        await base.HidePanel(duration);
    }

    private void DestroyCharacters()
    {
        foreach (var character in _characters)
        {
            Destroy(character.gameObject);
        }
        _characters.Clear();
    }
}
