using UnityEngine;

public class CameraMoverY : MonoBehaviour
{
    [SerializeField] private float _deadZoneYUp;
    [SerializeField] private float _deadZoneYDown;
    [SerializeField] private float _sensetivity;

    private void Update()
    {
        float mousePositionX = Input.GetAxis("Mouse Y");

        transform.Rotate(-mousePositionX * _sensetivity, 0, 0);
    }
}