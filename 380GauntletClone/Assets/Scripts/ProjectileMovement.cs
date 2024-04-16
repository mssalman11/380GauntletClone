using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Renderer m_Renderer;

    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward);

        if (!m_Renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
