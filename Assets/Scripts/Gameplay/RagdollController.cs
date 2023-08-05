using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    private List<Collider> colliders = new List<Collider>();

    private void OnEnable()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();
        foreach(var currentBody in bodies)
        {
            rigidbodies.Add(currentBody);
            colliders.Add(currentBody.GetComponent<Collider>());
        }
    }

    public void EnableRagdoll(bool enabled)
    {
        foreach(var rb in rigidbodies)
            rb.isKinematic = !enabled;

        foreach(var col in colliders)
            col.enabled = enabled;
    }
}
