using UnityEngine;
using Zenject;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private float _rotationSpeed;

    private readonly float _minVerticalAngle = -90f;
    private readonly float _maxVerticalAngle = 90f;

    private float _verticalRotation = 0f;

    private IInputController _inputController;

    [Inject]
    private void Construct(IInputController inputController)
    {
        _inputController = inputController;
    }

    private void Update()
    {
        float dirRotY = _inputController.GetAxisMouseY();
        Rotate(dirRotY, _rotationSpeed);
    }

    private void Rotate(float dirRotY, float rotSpeed)
    {
        _verticalRotation -= dirRotY * rotSpeed * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, _minVerticalAngle, _maxVerticalAngle);

        _camera.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
}
