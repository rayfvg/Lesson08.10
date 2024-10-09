using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private float _distanceToCheck;
    [SerializeField] private Transform _handPosition;
    [SerializeField] private float _smoothness;

    private GameObject _objectToMove;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Take();  
        }
        if (Input.GetMouseButtonUp(0))
        {
            DropItem();
        }
    }

    private void Take()
    {
        if (CanTake())
        {
            if (_objectToMove != null)
                MoveObjectToHand();
        }
    }

    private bool CanTake()
    {
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraRay, out raycastHit, _distanceToCheck))
        {
            if (raycastHit.collider.GetComponent<IDragger>() != null)
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

    private void DropItem()
    {
        if(_objectToMove != null)
        {
            _objectToMove.GetComponent<Rigidbody>().isKinematic = false;
            _handPosition.transform.DetachChildren();
        }
    }
}