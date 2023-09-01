using DG.Tweening;
using ModestTree;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStorePanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private RectTransform _panelRect;
    [field: SerializeField] private RectTransform _chooseRect;
    [field: SerializeField] private RectTransform _storeRect;
    [field: SerializeField] private StoreMenuPanel _menuPanelPrefab;
    [field: SerializeField] private Button _storeChoosePrefab;
    [field: SerializeField] private Image _panelImg;
    [field: SerializeField] private Button _closeButton;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private StoresDataProvider _storeProvider;

    private float _alpha;
    private Color _defaultColor;
    private List<StoreMenuPanel> _panels = new List<StoreMenuPanel>();
    private List<Button> _buttons = new List<Button>();
    private StoreMenuPanel _curStore;

    public void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        _defaultColor = _panelImg.color;
        _alpha = _defaultColor.a;
        _panelRect.gameObject.SetActive(false);
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
        _panelImg.color = _panelImg.color * new Color(1, 1, 1, 0);
        float alpha = _alpha;
        var color = _defaultColor * new Color(1, 1, 1, alpha);
        LoadStores();

        _panelImg.DOColor(color, duration);
        await Task.Delay((int)(duration * 1000));
    }

    private void LoadStores()
    {
        foreach (var store in _storeProvider.Stores)
        {
            var btn = Instantiate(_storeChoosePrefab, _chooseRect);
            btn.onClick.AddListener(async () => { await ShowStore(_storeProvider.Stores.IndexOf(store)); });
            _buttons.Add(btn);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = store.name; // TEMP

            var storeData = Instantiate(_menuPanelPrefab, _storeRect);
            storeData.Init(store);
            _panels.Add(storeData);
            storeData.ShowPanel(false);
        }

        _curStore = _panels[0];
        _curStore.ShowPanel(true);
    }

    private void UnloadStores()
    {
        foreach (var btn in _buttons)
            Destroy(btn.gameObject);
        foreach (var panel in _panels)
            Destroy(panel.gameObject);

        _buttons.Clear();
        _panels.Clear();
    }

    private async Task ShowStore(int id)
    {
        if (id < 0 || id >= _panels.Count)
            return;

        if (_panels.IndexOf(_curStore).Equals(id))
            return;

        var showType = _panels.IndexOf(_curStore) > id ? PanelAnimationType.Down : PanelAnimationType.Up;
        var hideType = _panels.IndexOf(_curStore) < id ? PanelAnimationType.Down : PanelAnimationType.Up;
        await _curStore.ShowPanel(false, showType);
        _curStore = _panels[id];
        await _curStore.ShowPanel(true, hideType);
    }

    public async Task HidePanel(float duration)
    {
        _panelImg.color = _defaultColor;
        float alpha = 0;
        var color = _defaultColor * new Color(1, 1, 1, alpha);

        UnloadStores();
        _panelImg.DOColor(color, duration / 4);
        await Task.Delay((int)(duration * 1000));
        _panelRect.gameObject.SetActive(false);
    }
}
