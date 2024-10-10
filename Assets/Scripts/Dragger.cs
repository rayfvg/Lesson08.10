using UnityEngine;

public class Dragger
{
    private float _distanceToCheck;
    private Transform _handPosition;
    private float _smoothness;

    private GameObject _objectToMove;
    private Camera _camera;

    public Dragger(float distanceToCheck, Transform handPosition, float smoothness)
    {
        _distanceToCheck = distanceToCheck;
        _handPosition = handPosition;
        _smoothness = smoothness;
    }

    public void Take()
    {
        if (CanTake())
        {
            if (_objectToMove != null)
                MoveObjectToHand();
        }
    }

    private bool CanTake()
    {
        _camera = Camera.main;
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraRay, out raycastHit, _distanceToCheck))
        {
            if (raycastHit.collider.GetComponent<Box>() != null)
            {
                _objectToMove = raycastHit.collider.gameObject;
                return true;
            }
        }
        return false;
    }

    private void MoveObjectToHand()
    {
        _objectToMove.GetComponent<Rigidbody>().isKinematic = true;
        _objectToMove.transform.position = Vector3.Lerp(_objectToMove.transform.position, _handPosition.position, _smoothness * Time.deltaTime);
        _objectToMove.transform.parent = _handPosition.transform;
    }

    public void DropItem()
    {
        if (_objectToMove != null)
        {
            _objectToMove.GetComponent<Rigidbody>().isKinematic = false;
            _handPosition.transform.DetachChildren();
        }
    }
}