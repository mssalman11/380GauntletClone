using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Renderer m_Renderer;
    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();  
        StartCoroutine(DestroyAfterCreate());

    }

    IEnumerator DestroyAfterCreate()
    {
        yield return new WaitForSeconds(1.5f);
        if (!m_Renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.CompareTag("WarriorP"))
                PlayerScores.WarriorScore += 10;
            if (gameObject.CompareTag("ValkyrieP"))
                PlayerScores.ValkyrieScore += 10;
            if (gameObject.CompareTag("WizardP"))
                PlayerScores.WizardScore += 10;
            if (gameObject.CompareTag("ElfP"))
                PlayerScores.ElfScore += 10;

        }
    }
}
