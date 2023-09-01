using UnityEngine;

public class StoresDataProvider
{
    private StoreData[] _stores;

    public StoresDataProvider()
    {
        _stores = Resources.LoadAll<StoreData>("StoreData/");
    }

    public StoreData[] Stores => _stores;
}
