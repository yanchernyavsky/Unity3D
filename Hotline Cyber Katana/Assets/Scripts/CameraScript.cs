using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform trackedObject, targetCamera;
    public Vector3 offset;
    Transform currentTrackedObject;
 
    void Start()
    {
        currentTrackedObject = trackedObject;
    }
    void FixedUpdate()
    {
        targetCamera.position = Vector3.Lerp(targetCamera.position, currentTrackedObject.position, 0.05f) + offset;
    }
}
