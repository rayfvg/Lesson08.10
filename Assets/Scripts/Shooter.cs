using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private ExplotionShoter _explotionShoter;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _explotionShoter.Shoot();
        }
    }
}