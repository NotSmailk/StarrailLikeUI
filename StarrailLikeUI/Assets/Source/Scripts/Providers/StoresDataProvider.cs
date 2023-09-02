using UnityEngine;

public class StoresDataProvider
{
    private StoreData[] _stores;

    public StoresDataProvider()
    {
        _stores = Resources.LoadAll<StoreData>(GameConstants.Paths.STORE_PATH);
    }

    public StoreData[] Stores => _stores;
}
