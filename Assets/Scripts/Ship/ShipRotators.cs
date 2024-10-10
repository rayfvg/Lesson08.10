using UnityEngine;

public class ShipRotators : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, _speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -_speed * Time.deltaTime);
        }
    }
}