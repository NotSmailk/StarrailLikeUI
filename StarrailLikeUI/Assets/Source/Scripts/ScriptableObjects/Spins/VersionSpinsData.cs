using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spin/VersionSpinsData", fileName = "New Spins Data")]
public class VersionSpinsData : ScriptableObject
{
    [field: SerializeField] private List<SpinData> _datas = new List<SpinData>();

    public List<SpinData> Datas => _datas;
}
