using UnityEngine;

public class ExplotionShoter : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _explosionForce;

    [SerializeField] private ParticleSystem _explosionParticle;

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Instantiate(_explosionParticle, hitInfo.point, Quaternion.identity);

            Collider[] targets = Physics.OverlapSphere(hitInfo.point, _radiusExplosion);
            
            foreach (Collider target in targets)
            {
                if (target.GetComponent<IPhysical>() != null)
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