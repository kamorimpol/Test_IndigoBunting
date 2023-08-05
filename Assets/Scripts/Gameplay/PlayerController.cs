using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Unit character;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera camera;
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private Vector3 pushDirection = new Vector3(0, 0, 1);
    private bool isPushible = true;
    void Update()
    {
        if(isPushible && Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                LevelController.Instance.StartLevel();
                isPushible = false;

                character.Push(pushDirection, hit.rigidbody, pushForce);
                Debug.Log(hit.rigidbody.gameObject.name);
            }
        }
    }
}
