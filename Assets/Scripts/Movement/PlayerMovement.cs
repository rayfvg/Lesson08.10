using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string UserInputX = "Horizontal";
    private const string UserInputZ = "Vertical";

    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Vector3 _movement;
    private Camera _camera;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float positionX = Input.GetAxis(UserInputX);
        float positionZ = Input.GetAxis(UserInputZ);

        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.y = 0;
        right.y = 0;

        _movement = right * positionX + forward * positionZ;

        float mousePositionY = Input.GetAxis("Mouse X");
        transform.Rotate(0,mousePositionY,0);
    }

    private void FixedUpdate()
    {
        _characterController.Move(_movement.normalized * Time.deltaTime * _speed);
    }
}