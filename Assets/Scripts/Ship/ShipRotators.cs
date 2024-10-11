using UnityEngine;

public class ShipRotators
{
    private Transform _ship;
    private float _speed;

    public ShipRotators(Transform ship, float speed)
    {
        _ship = ship;
        _speed = speed;
    }

    public void TurnLeft() => _ship.Rotate(Vector3.up, _speed * Time.deltaTime);

    public void TurnRight() => _ship.Rotate(Vector3.up, -_speed * Time.deltaTime);
}