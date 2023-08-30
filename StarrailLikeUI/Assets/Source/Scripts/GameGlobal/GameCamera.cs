using DG.Tweening;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [field: SerializeField] private Camera _camera;

    private Vector3 _inWorldPosition;
    private Quaternion _inWorldRotation;

    public Vector3 WorldPosition => _inWorldPosition;
    public Quaternion WorldRotation => _inWorldRotation;
    public Transform CameraTransform => _camera.transform;

    public void Init()
    {
        RememperPositionAndRotation();
    }

    public void RememperPositionAndRotation()
    {
        _inWorldPosition = _camera.transform.position;
        _inWorldRotation = _camera.transform.rotation;
    }

    public void SetWorldPositionAndRotation(Vector3 target, float duration)
    {
        _camera.transform.position = target;
        _camera.transform.DOMove(_inWorldPosition, duration);
        _camera.transform.rotation = _inWorldRotation;
    }

    public void SetPositionAndRotation(Vector3 middlePos, Vector3 pos, Quaternion rot, float duration)
    {
        _camera.transform.position = middlePos;
        _camera.transform.DOMove(pos, duration);
        _camera.transform.rotation = rot;
    }
}
