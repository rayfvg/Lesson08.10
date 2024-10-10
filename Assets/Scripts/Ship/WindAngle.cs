using UnityEngine;

public class WindAngle
{
    private Transform _salt;
    private Transform _wind;

    public WindAngle(Transform salt, Transform wind)
    {
        _salt = salt;
        _wind = wind;
    }

    public float GettingWindAngle()
    {
        Vector3 directionSalt = new Vector3(-_salt.transform.forward.x, 0, -_salt.transform.forward.z);

        Vector3 forwardDirectionWind = new Vector3(_wind.transform.forward.x, 0, _wind.transform.forward.z);

        //Debug.DrawRay(_salt.position, directionToTarget * 5, Color.red, 0.1f);
        //Debug.DrawRay(_wind.transform.position, forwardDirection * 5, Color.gray, 0.1f);

        float dotProduct = Vector3.Dot(directionSalt, forwardDirectionWind);

        float degreetToTarget = Mathf.Acos(dotProduct / (directionSalt.magnitude * forwardDirectionWind.magnitude)) * Mathf.Rad2Deg;

        return degreetToTarget;
    }
}