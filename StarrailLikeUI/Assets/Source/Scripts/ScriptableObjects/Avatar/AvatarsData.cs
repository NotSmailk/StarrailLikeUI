using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Avatar/Avatars Data", fileName = "New Avatars Data")]
public class AvatarsData : ScriptableObject
{
    [field: SerializeField] private List<Sprite> _avatars = new List<Sprite>();

    public Sprite GetAvatar(int id)
    {
        if (id <= 0 || id > _avatars.Count)
            return _avatars[0];

        return _avatars[id];
    }
}
