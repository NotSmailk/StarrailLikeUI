using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] private Animator _animator;
    [field: SerializeField] private PlayerAnimationData _animationData;
    [field: SerializeField] private Transform _phoneViewPoint;
    [field: SerializeField] private Phone _phone;

    public Transform PhoneViewPoint => _phoneViewPoint;

    public void EnterPhoneMode()
    {
        _phone.ShowPhone(true);
        AnimatorHelper.SetBoolParameter(
            _animator,
            _animationData.PickUpThePhoneParameter,
            true);
    }

    public void EnterWorldMode()
    {
        _phone.ShowPhone(false);
        AnimatorHelper.SetBoolParameter(
            _animator,
            _animationData.PickUpThePhoneParameter,
            false);
    }
}
