using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DeviceInfoPanel : MonoBehaviour
{
    [field: SerializeField] private Image _connectionImg;
    [field: SerializeField] private Slider _batterySlider;

    [Inject] private DeviceInfoProvider _deviceInfoProvider;

    public void ShowPanel()
    {
        _connectionImg.gameObject.SetActive(_deviceInfoProvider.Reachability != NetworkReachability.NotReachable);
        _batterySlider.value = _deviceInfoProvider.BatterLevel;
    }

    public void GameUpdate()
    {
        _batterySlider.value = _deviceInfoProvider.BatterLevel;
    }
}
