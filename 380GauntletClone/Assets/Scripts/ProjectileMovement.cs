using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Renderer m_Renderer;

    private Rigidbody projectileRB;
    private float speed;
    private float horizontalInput;
    private float verticalInput;
    private void Awake()
    {
        speed = 5f;
        m_Renderer = GetComponent<Renderer>();
        projectileRB = GetComponent<Rigidbody>();
        
        

        StartCoroutine(DestroyAfterCreate());
    }
    private void Update()
    {
        /*if (!m_Renderer.isVisible)
        {
            Destroy(this.gameObject);
        }*/
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        //Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;


        //transform.position += movementDirection * speed * Time.deltaTime;
        //projectileRB.AddForce(Vector3.forward * speed);
        //projectileRB.velocity = (Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator DestroyAfterCreate()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }
}
