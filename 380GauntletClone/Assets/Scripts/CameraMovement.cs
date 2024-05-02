using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraPosition;

    private void Awake()
    {
        Vector3 cameraPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
    
    private void LateUpdate()
    {

        transform.position = cameraPosition;
    }
}
