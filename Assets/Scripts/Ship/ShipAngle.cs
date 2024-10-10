using UnityEngine;

public class ShipAngle
{
    private ShipMover _ship;

    public ShipAngle(ShipMover ship)
    {
        _ship = ship;
    }

    public float GettingShipAngle()
    {
        Vector3 directionLocal = new Vector3(_ship.transform.forward.x, 0, _ship.transform.forward.z);
        Vector3 directionMovement = _ship.GetComponent<Rigidbody>().velocity;

       // Debug.DrawRay(_ship.transform.position, directionLocal * 40, Color.red, 0.01f);
       // Debug.DrawRay(_ship.transform.position, directionMovement * 40, Color.green, 0.01f);

        float dotProduct = Vector3.Dot(directionMovement, directionLocal);

        float degreetToTarget = Mathf.Acos(dotProduct / (directionMovement.magnitude * directionLocal.magnitude)) * Mathf.Rad2Deg;

        return degreetToTarget;
    }
}