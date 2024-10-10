using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _explosionParticle;

    private ExplotionShoter _explotionShoter;

    private void Awake()
    {
        _explotionShoter = new ExplotionShoter(_radiusExplosion, _explosionForce, _explosionParticle);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _explotionShoter.Shoot();
        }
    }
}