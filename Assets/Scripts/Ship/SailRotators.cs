using UnityEngine;

public class SailRotators
{
    private float _speedRotation;
    private Transform _sail;

    private float _rotationY;

    public SailRotators(Transform sail, float speedRotation)
    {
        _speedRotation = speedRotation;
        _sail = sail;

        _rotationY = _sail.localEulerAngles.y;
    }

    public void UpdateRotationY()
    {
        _rotationY = NormalizeAngle(_rotationY);
        _rotationY = Mathf.Clamp(_rotationY, -90f, 90f);
        _sail.localEulerAngles = new Vector3(0, _rotationY, 0);
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180) angle -= 360;
        return angle;
    }

    public void TurnLeft() => _rotationY -= _speedRotation * Time.deltaTime;

    public void TurnRight() => _rotationY += _speedRotation * Time.deltaTime;
}