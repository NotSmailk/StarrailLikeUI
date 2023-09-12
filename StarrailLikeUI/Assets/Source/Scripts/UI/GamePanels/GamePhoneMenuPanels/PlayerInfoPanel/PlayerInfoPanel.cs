using UnityEngine;

public class PlayerInfoPanel : MonoBehaviour
{
    [field: SerializeField] private DeviceInfoPanel _deviceInfoPanel;
    [field: SerializeField] private PlayerLevelInfoPanel _playerLevelInfoPanel;
    [field: SerializeField] private PlayerDataPanel _playerDataPanel;

    public void ShowPanel()
    {
        _deviceInfoPanel.ShowPanel();
        _playerLevelInfoPanel.ShowPanel();
        _playerDataPanel.ShowPanel();
    }

    public void GameUpdate()
    {
        _deviceInfoPanel.GameUpdate();
    }
}
