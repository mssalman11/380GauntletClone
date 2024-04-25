using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyObjectPoolContainer : MonoBehaviour
{
    private EnemyObjectPool _pool;

    private void Start()
    {
        _pool = gameObject.AddComponent<EnemyObjectPool>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn Some Drones"))
        {
            _pool.Spawn();
        }
    }

}
