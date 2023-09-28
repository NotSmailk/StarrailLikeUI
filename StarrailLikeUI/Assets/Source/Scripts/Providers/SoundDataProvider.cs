using UnityEngine;

public class SoundDataProvider
{
    private SoundData _data;

    public SoundDataProvider()
    {
        _data = Resources.Load<SoundData>(GameConstants.Paths.SOUND_DATA_PATH);
    }

    public SoundData Data => _data;
}
