using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] float pushForce = 10f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Vector3 explosionOffset = Vector3.zero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
            foreach (var box in hitColliders)
            {
                Vector3 explosionPoint = new Vector3(transform.position.x, 0, transform.position.z) + explosionOffset;
                box.GetComponent<Rigidbody>().AddExplosionForce(pushForce, explosionPoint, radius);
            }
            Destroy(gameObject);
        }
    }
}
