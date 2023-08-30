using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player/Animation Data", fileName = "New Animation Data")]
public class PlayerAnimationData : ScriptableObject
{
    [field: SerializeField] private string _idleKey = "Idle";
    [field: SerializeField] private string _pickUpThePhoneKey = "PickUpThePhone";
    [field: SerializeField] private string _phoneIdleKey = "PhoneIdle";
    [field: SerializeField] private string _pickUpThePhoneParameter = "PickUpThePhone";

    public string IdleKey => _idleKey;
    public string PickUpThePhoneKey => _pickUpThePhoneKey;
    public string PhoneIdleKey => _phoneIdleKey;
    public string PickUpThePhoneParameter => _pickUpThePhoneParameter;
}
