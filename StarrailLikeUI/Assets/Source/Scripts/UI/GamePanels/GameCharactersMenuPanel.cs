using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameCharactersMenuPanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private CharacterViewList _characterViewList;
    [field: SerializeField] private RectTransform _panelRect;
    [field: SerializeField] private Transform _viewpoint;
    [field: SerializeField] private Image _panelImg;
    [field: SerializeField] private Button _closeButton;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private SquadData _squadData;

    private float _alpha;
    private List<GameObject> _characters = new List<GameObject>();
    private GameObject _selectedCharacter;
    private Color _defaultColor;

    public void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        _defaultColor = _panelImg.color;
        _alpha = _defaultColor.a;
        _panelRect.gameObject.SetActive(false);
        _characterViewList.Init(SetActivePlayer, _squadData);
    }

    private void SetActivePlayer(int id)
    {
        if (id < 0 || id >= _characters.Count)
            return;

        if (_characters.IndexOf(_selectedCharacter).Equals(id))
            return;

        foreach (var character in _characters)
            character.SetActive(false);

        _selectedCharacter = _characters[id];
        _characters[id].SetActive(true);
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
        foreach (var character in _squadData.Squad)
        {
            var player = Instantiate(character.CharacterUIPrefab, _viewpoint);
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
            Destroy(character);
        }
        _characters.Clear();
    }
}