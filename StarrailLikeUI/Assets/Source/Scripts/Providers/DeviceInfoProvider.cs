using UnityEngine;

public class DeviceInfoProvider
{
    public float BatterLevel => SystemInfo.batteryLevel;
    public NetworkReachability Reachability => Application.internetReachability;
}
