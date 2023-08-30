using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Level/LevelsData", fileName = "New Levels Data")]
public class LevelsData : ScriptableObject
{
    [field: SerializeField] private List<LevelData> _data = new List<LevelData>();

    public List<LevelData> Data => _data;
}
