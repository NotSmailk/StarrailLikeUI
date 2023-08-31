using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Squad", fileName = "New Squad Data")]
public class SquadData : ScriptableObject
{
    [field: SerializeField] private List<int> _squad;

    public List<int> Squad => _squad;
}
