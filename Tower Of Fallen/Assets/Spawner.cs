using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Item[] items;
    [SerializeField] private Transform[] enemySpawnPoints;
    [SerializeField] private Transform[] itemSpawnPoints;
    private bool[] itemIndex;
    private int enemyLimit = 10;
    private int enemyCounter = 0;
    private float enemyTime = 0f;
    private float enemySpawnTime = 2f;
    private float itemTime = 0f;
    private float itemSpawnTime = 3f;


    private void Start()
    {
        itemIndex = new bool[itemSpawnPoints.Length];
        for (int i = 0; i < itemSpawnPoints.Length; i++)
        {
            itemIndex[i] = false;
        }
    }

    //Update is called once per frame
    void Update()
    {
        enemyTime += Time.deltaTime;
        itemTime += Time.deltaTime;

        SpawnEnemy();
        SpawnItem();

    }

    void SpawnEnemy()
    {
        if (enemyTime > enemySpawnTime && enemyCounter < enemyLimit)
        {
            enemyTime = 0;
            enemyCounter += 1;
            GameObject enemy = enemies[Random.Range(0, enemies.Length)].gameObject;
            Transform enemySpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

            Instantiate(enemy, enemySpawnPoint.position, Quaternion.identity);
        }
    }

    void SpawnItem()
    {
        if (itemTime > itemSpawnTime)
        {
            itemTime = 0;
            int spotNum = Random.Range(0, itemSpawnPoints.Length);
            if (itemIndex[spotNum] == false)
            {
                itemIndex[spotNum] = true;
                GameObject item = items[Random.Range(0, items.Length)].gameObject;
                Transform itemSpawnPoint = itemSpawnPoints[spotNum];

                Instantiate(item, itemSpawnPoint.position, Quaternion.identity);
            }
            
        }
    }
}
