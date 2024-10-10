using UnityEngine;

public class Management : MonoBehaviour
{
    [SerializeField] private float _distanceToCheck;
    [SerializeField] private Transform _handPosition;
    [SerializeField] private float _smoothness;

    private Dragger _dragger;

    private void Awake()
    {
        _dragger = new Dragger(_distanceToCheck, _handPosition, _smoothness);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragger.Take();
        }
        if (Input.GetMouseButtonUp(0))
        {
            _dragger.DropItem();
        }
    }
}
