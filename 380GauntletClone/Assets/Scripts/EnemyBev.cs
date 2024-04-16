using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBev : MonoBehaviour
{
    protected int enemyHealth;
    protected int enemyLevel;
    protected int enemyDamage;

    [SerializeField]
    private float speed;

    public GameObject TESTPLAYER;
    public Vector3 distance;

    public virtual void EnemyMove()
    {
        transform.Translate(getDistance() * Time.deltaTime * speed);
    }

    public Vector3 getDistance()
    {
        distance = TESTPLAYER.GetComponent<Transform>().position - GetComponent<Transform>().position;

        return distance;
    } 

    private void Die()
    {
        if (enemyHealth < 0)
        {
            Destroy(this);
        }
    }

}
