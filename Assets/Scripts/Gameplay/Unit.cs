using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private RagdollController ragdollController;
    [SerializeField] private UnitAnimation animation;
    [SerializeField] private Transform ragdollPoint;

    public void Push(Vector3 direction, Rigidbody body, float force)
    {
        animation.DisableAnimations();
        // ragdollController.EnableRagdoll(true);
        body.AddForce(direction * force, ForceMode.Impulse);
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        animation.EnableDancing();
        transform.position = new Vector3(ragdollPoint.position.x, 0f, ragdollPoint.position.z);
        LevelController.Instance.EndLevel();
        // ragdollController.EnableRagdoll(false);

    }
}
