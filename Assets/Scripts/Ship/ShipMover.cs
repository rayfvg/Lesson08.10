using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ShipMover : MonoBehaviour
{
    [SerializeField] private Transform _salt;
    [SerializeField] private Transform _wind;

    [SerializeField] private float _baseSpeed;
    [SerializeField] private float _slowingSpeedModify;
    [SerializeField] private float _slowingDragModify;

    [SerializeField] private TMP_Text _textSpeed;
    [SerializeField] private TMP_Text _textSlowing;

    private Rigidbody _rigigbody;
    private WindAngle _windAngle;
    private ShipAngle _shipAngle;

    private float _minSpeedForMove = 30;
    private float _maxSpeedForMove = 180;
    private float _currentSpeed;
    private float _currentSlowing;

    private void Awake()
    {
        _rigigbody = GetComponent<Rigidbody>();
        _windAngle = new WindAngle(_salt, _wind);
        _shipAngle = new ShipAngle(this);
    }

    private void Update()
    {
        _currentSpeed = _windAngle.GettingWindAngle() / _slowingSpeedModify;
        _currentSlowing = Mathf.Lerp(0, 20, _shipAngle.GettingShipAngle() / _slowingDragModify);
    }

    private void FixedUpdate()
    {
        if (_currentSpeed > _minSpeedForMove && _currentSpeed < _maxSpeedForMove)
        {
            _rigigbody.AddForce(transform.forward * _currentSpeed * _baseSpeed, ForceMode.Force);
            _textSpeed.text = "Скорость корабля " + Mathf.Abs((_rigigbody.velocity.z * _baseSpeed * 10)).ToString("0,0");
        }
            
        if (_rigigbody.velocity.magnitude > 2f && _currentSlowing > 5)
        {
            _rigigbody.drag = 5;
        }
        else
        {
            _rigigbody.drag = 1;
        }
    }
}