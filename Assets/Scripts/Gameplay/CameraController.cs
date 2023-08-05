using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float followSpeed = 7f;
    private bool isFollow = false;

    private void Awake()
    {
        LevelController.Instance.OnStart += (() => isFollow = true);
        LevelController.Instance.OnEnd += (() => isFollow = false);
    }

    private void LateUpdate()
    {
        if(isFollow)
        {
            Vector3 nextPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * followSpeed);
        }
    }
}
