using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;

    private Rigidbody _rb;
    private IInputController _inputController;


    [Inject]
    private void Construct(IInputController inputController)
    {
        _inputController = inputController;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float dirX = _inputController.GetAxisHorizontal();
        float dirZ = _inputController.GetAxisVertical();
        Movement(dirZ, dirX, _movementSpeed);

       
    }

    private void Update()
    {
        float dirRotX = _inputController.GetAxisMouseX();
        Rotate(dirRotX, _rotationSpeed);
    }

    private void Movement(float dirZ, float dirX, float speed)
    {
        Vector3 gravity = new Vector3(0, _rb.velocity.y, 0);
        _rb.velocity = gravity + CalculateDirection(dirZ, dirX) * speed;
    }

    public void Rotate(float dirRotX, float rotSpeed)
    {
        gameObject.transform.Rotate(Vector3.up * dirRotX * rotSpeed * Time.deltaTime);
    }

    private Vector3 CalculateDirection(float inputZ, float inputX)
    {
        return gameObject.transform.forward * inputZ + gameObject.transform.right * inputX;
    }



}
