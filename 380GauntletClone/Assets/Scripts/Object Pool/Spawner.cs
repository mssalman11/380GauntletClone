using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timebetweenSpawns = 5f;

    private float lastSpawnTime;

    [SerializeField] private EnemyBev enemyPrefab;

    private IObjectPool<EnemyBev> enemyPool;

    private void Awake()
    {
        enemyPool = new ObjectPool<EnemyBev>(CreateEnemy, OnGet, OnRelease);
    }

    private EnemyBev CreateEnemy()
    {
        EnemyBev enemy = Instantiate(enemyPrefab);
        enemy.SetPool(enemyPool);
        return enemy;
    }

    private void OnGet(EnemyBev enemy)
    {
        enemy.gameObject.SetActive(true);
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        enemy.transform.position = randomSpawnPoint.position;
    }

    private void OnRelease(EnemyBev enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime)
        {
            enemyPool.Get();
            lastSpawnTime = Time.time + timebetweenSpawns;
        }
    }
}
