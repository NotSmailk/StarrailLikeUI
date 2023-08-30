using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/Player/Squad", fileName = "New Squad Data")]
public class SquadData : ScriptableObject
{
    [field: SerializeField] private List<CharacterData> _squad = new List<CharacterData>();

    public List<CharacterData> Squad => _squad;
}
