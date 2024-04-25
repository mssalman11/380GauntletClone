using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 3;
    public int stackDefaultCapacity = 3;
    private IObjectPool<SkeletonEnemy> _pool;
    public GameObject prefabtest;

    public IObjectPool<SkeletonEnemy> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<SkeletonEnemy>(CreatedPooledItem, OneTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSize);

            }
            return _pool;
        }
    }

    private SkeletonEnemy CreatedPooledItem()
    {
        var go = Instantiate(prefabtest);

        SkeletonEnemy skeleton = go.AddComponent<SkeletonEnemy>();

        go.name = "Skeleton";
        skeleton.Pool = Pool;

        return skeleton;
    }

    private void OneTakeFromPool(SkeletonEnemy sk)
    {
        sk.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(SkeletonEnemy sk)
    {
        sk.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(SkeletonEnemy sk)
    {
        Destroy(sk.gameObject);
    }

    public void Spawn()
    {
        var amount = Random.Range(1, 3);

        for (int i = 0; i < amount; i++)
        {
            var skele = Pool.Get();
            skele.transform.position = Random.insideUnitSphere * 10;
        }


    }

}
