using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static List<Transform> targets;

    private Vector3 offset;
    private Vector3 newPosition;
    private Vector3 centerPoint;
    private void Awake()
    {
        offset = new Vector3(5f, 1.5f, 0f);

        targets = new List<Transform>();
    }
    
    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        centerPoint = GetCenterPoint();

        newPosition = centerPoint + offset;
        
        transform.position = newPosition;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
