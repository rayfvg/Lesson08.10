using TMPro;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    [SerializeField] private Transform _salt;
    [SerializeField] private Transform _wind;
    [SerializeField] private Transform _ship;

    [SerializeField] private float _speedShip;
    [SerializeField] private float _speedSalt;

    [SerializeField] private TMP_Text _textSpeed;

    private Rigidbody _rigigbody;
    private WindAngle _windAngle;


    private void Awake()
    {
        _rigigbody = GetComponent<Rigidbody>();
        _windAngle = new WindAngle(_salt, _wind, _ship);
    }

    private void Update()
    {
        Debug.Log("вектор паруса" + _windAngle.GettingWindAngle());
        Debug.Log("Вектор корабля" + _windAngle.GettingShipAngle());

        float movementY = _windAngle.GettingWindAngle() * _speedShip * _windAngle.GettingShipAngle() * _speedSalt;
        Vector3 direction = _ship.forward;

        if (movementY > 0)
            _rigigbody.AddForce(direction * movementY * Time.deltaTime, ForceMode.Force);

        _textSpeed.text = "Скорость корабля: " + (_rigigbody.velocity.magnitude * 10f).ToString("0,0");
    }
}