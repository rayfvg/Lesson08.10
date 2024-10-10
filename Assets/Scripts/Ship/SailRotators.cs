using UnityEngine;

public class SailRotators : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _returnSpeed;

    private float _startYRotation;
    private float _rotationY;
    private bool _isReturning;

    private void Start()
    {
        _startYRotation = transform.localEulerAngles.y;
    }

    private void Update()
    {
        _rotationY = transform.localEulerAngles.y;

        _rotationY = NormalizeAngle(_rotationY);

        if (Input.GetKey(KeyCode.Q))
        {
            _isReturning = false;
            _rotationY -= _speedRotation * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.E))
        {
            _isReturning = false;
            _rotationY += _speedRotation * Time.deltaTime;
        }
        else
        {
            _isReturning = true;
        }

            _rotationY = Mathf.Clamp(_rotationY, -90f, 90f);

        if (_isReturning == false)
            transform.localEulerAngles = new Vector3(0, _rotationY, 0);

        if (_isReturning == true)
            ReturnStartRotation();   
    }

    private float NormalizeAngle(float angle)  //это я нагуглил кое как. в душе не понимаю что это, но только так работает
    {
        angle = angle % 360;
        if (angle > 180) angle -= 360;
        return angle;
    }

    private void ReturnStartRotation()
    {
        float smoothRotation = Mathf.Lerp(_rotationY, _startYRotation, _returnSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, smoothRotation, 0);
    }
}