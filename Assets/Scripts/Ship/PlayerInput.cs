using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform _ship;
    [SerializeField] private Transform _sail;

    [SerializeField] private float _speedRotationSail;
    [SerializeField] private float _speedRotationShip;

    private ShipRotators _shipRotators;
    private SailRotators _sailRotators;

    private void Awake()
    {
        _shipRotators = new ShipRotators(_ship, _speedRotationShip);
        _sailRotators = new SailRotators(_sail, _speedRotationSail);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            _shipRotators.TurnLeft();
        
        
        if (Input.GetKey(KeyCode.Q))
            _shipRotators.TurnRight();


        if (Input.GetKey(KeyCode.A))
            _sailRotators.TurnLeft();
        

        if (Input.GetKey(KeyCode.D))
            _sailRotators.TurnRight();

        _sailRotators.UpdateRotationY();
    }
}