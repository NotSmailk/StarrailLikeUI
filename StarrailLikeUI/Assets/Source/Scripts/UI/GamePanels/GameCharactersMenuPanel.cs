using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameCharactersMenuPanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private CharactersMenuTypeList _charactersMenuTypeList;
    [field: SerializeField] private CharacterViewChooseList _characterViewList;
    [field: SerializeField] private CharactersMenuInfoPanel _charactersMenuInfoPanel;
    [field: SerializeField] private CharactersMenuSkillsPanel _charactersMenuSkillsPanel;
    [field: SerializeField] private RectTransform _panelRect;
    [field: SerializeField] private Transform _viewpoint;
    [field: SerializeField] private Image _panelImg;
    [field: SerializeField] private Button _closeButton;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private SquadData _squadData;
    [Inject] private CharactersDataProvider _provider;

    private float _alpha;
    private List<CharacterUIView> _characters = new List<CharacterUIView>();
    private Dictionary<Type, ICharactersMenuPanel> _panels = new Dictionary<Type, ICharactersMenuPanel>();
    private CharacterUIView _selectedCharacter;
    private ICharactersMenuPanel _curPanel;
    private Color _defaultColor;

    public void Init()
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

    public void ShowPanelForce(bool show)
    {
        _panelRect.gameObject.SetActive(show);
    }

    public async Task ShowPanel(bool show, float duration)
    {
        if (show)
            await ShowPanel(duration);
        else
            await HidePanel(duration);
    }

    public async Task ShowPanel(float duration)
    {
        _panelRect.gameObject.SetActive(true);
        CreateCharacters();
        _panelImg.color = _panelImg.color * new Color(1, 1, 1, 0);
        float alpha = _alpha;
        var color = _defaultColor * new Color(1, 1, 1, alpha);

        _panelImg.DOColor(color, duration);
        await Task.Delay((int)(duration * 1000));
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

    public async Task HidePanel(float duration)
    {
        _panelImg.color = _defaultColor;
        float alpha = 0;
        var color = _defaultColor * new Color(1, 1, 1, alpha); 
        DestroyCharacters();

        _panelImg.DOColor(color, duration / 4);
        await Task.Delay((int)(duration * 1000));
        _panelRect.gameObject.SetActive(false);
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
