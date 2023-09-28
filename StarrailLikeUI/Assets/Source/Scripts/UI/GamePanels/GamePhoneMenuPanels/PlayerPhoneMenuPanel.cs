using UnityEngine;

public class PlayerPhoneMenuPanel : MonoBehaviour
{
    [field: SerializeField] private PlayerInfoPanel _playerInfoPanel;
    [field: SerializeField] private PhoneButtonsPanel _phoneButtonsPanel;

    public void Init()
    {
        _phoneButtonsPanel.Init();
    }

    public void ShowPanel(bool show)
    {
        _phoneButtonsPanel.Interactble(show);
        _playerInfoPanel.ShowPanel();
    }

    public void GameUpdate()
    {
        _playerInfoPanel.GameUpdate();
    }
}
