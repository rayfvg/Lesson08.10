using UnityEngine;

public class WindAngle
{
    private Transform _salt;
    private Transform _wind;
    private Transform _ship;

    public WindAngle(Transform salt, Transform wind, Transform ship)
    {
        _salt = salt;
        _wind = wind;
        _ship = ship;
    }

    public float GettingWindAngle()
    {
        Vector3 directionSalt = new Vector3(_salt.transform.forward.x, 0, _salt.transform.forward.z);

        Vector3 directionWind = new Vector3(_wind.transform.forward.x, 0, _wind.transform.forward.z);

        float dotProduct = Vector3.Dot(directionSalt, directionWind);

        return dotProduct;
    }

    public float GettingShipAngle()
    {
        Vector3 directionShip = new Vector3(_ship.transform.forward.x, 0, _ship.transform.forward.z);

        Vector3 directionSalt = new Vector3(_salt.transform.forward.x, 0, _salt.transform.forward.z);

        float dotProduct = Vector3.Dot(directionSalt, directionShip);

        return dotProduct;
    }
}