using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _smoothness;
    [SerializeField] private float _speedRotation;

    private float _timeForUpdateDirection;
    private Vector3 _randomDirection;
    private Vector3 _currentRotation;

    private void Update()
    {
        _timeForUpdateDirection += Time.deltaTime * _speedRotation;

        if(_timeForUpdateDirection > 1)
        {
            UpdateDirection();
            _timeForUpdateDirection = 0;
        }

        float rotationY = Mathf.LerpAngle(_currentRotation.y, _randomDirection.y, _timeForUpdateDirection * _smoothness);
        transform.eulerAngles = new Vector3(0, rotationY, 0);
    }

    private void UpdateDirection()
    {
        _currentRotation = transform.eulerAngles;
        _randomDirection = new Vector3(0, Random.Range(0, 360), 0);
    }
}