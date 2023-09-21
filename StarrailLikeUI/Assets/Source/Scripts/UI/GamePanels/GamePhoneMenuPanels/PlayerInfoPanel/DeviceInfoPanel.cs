using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DeviceInfoPanel : MonoBehaviour
{
    [field: SerializeField] private Image _connectionImg;
    [field: SerializeField] private Sprite _connectionReachable;
    [field: SerializeField] private Sprite _connectionNotReachable;
    [field: SerializeField] private Slider _batterySlider;

    [Inject] private DeviceInfoProvider _deviceInfoProvider;

    public void ShowPanel()
    {
        _connectionImg.sprite = _deviceInfoProvider.Reachability.Equals(NetworkReachability.NotReachable) ? 
            _connectionNotReachable : 
            _connectionReachable;
        _batterySlider.value = _deviceInfoProvider.BatterLevel;
    }

    public void GameUpdate()
    {
        _connectionImg.sprite = _deviceInfoProvider.Reachability.Equals(NetworkReachability.NotReachable) ?
            _connectionNotReachable :
            _connectionReachable;
        _batterySlider.value = _deviceInfoProvider.BatterLevel;
    }
}
