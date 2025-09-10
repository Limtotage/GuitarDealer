using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, -1, -10f);
    public float smoothTime = 0.12f;

    Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPos = new Vector3(target.position.x,target.position.y,0) + offset;
        Vector3 smoothed = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
        transform.position = smoothed;
    }
}
