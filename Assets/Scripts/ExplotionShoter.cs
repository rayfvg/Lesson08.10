using UnityEngine;

public class ExplotionShoter
{
    private float _radiusExplosion;
    private float _explosionForce;

    private ParticleSystem _explosionParticle;

    public ExplotionShoter(float radiusExplosion, float explosionForce, ParticleSystem explosionParticle)
    {
        _radiusExplosion = radiusExplosion;
        _explosionForce = explosionForce;
        _explosionParticle = explosionParticle;
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Object.Instantiate(_explosionParticle, hitInfo.point, Quaternion.identity);

            Collider[] targets = Physics.OverlapSphere(hitInfo.point, _radiusExplosion);

            foreach (Collider target in targets)
            {
                if (target.GetComponent<Box>() != null)
                {
                    Vector3 direction = (target.transform.position - hitInfo.point).normalized;

                    Rigidbody targetRigitBody = target.GetComponent<Rigidbody>();

                    if (targetRigitBody != null)
                    {
                        targetRigitBody.AddForce(direction * _explosionForce, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}