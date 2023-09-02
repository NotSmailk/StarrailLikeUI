using UnityEngine;

public class SpinsDataProvider
{
    private VersionSpinsData _spinsData;

    public SpinsDataProvider()
    {
        _spinsData = Resources.Load<VersionSpinsData>(GameConstants.Paths.SPINS_PATH);
    }

    public VersionSpinsData SpinsData => _spinsData;
}
