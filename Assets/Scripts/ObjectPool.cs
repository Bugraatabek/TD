using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    GameObject[] pool;
    
    void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }
    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(Enemy, transform.position, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }
        void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
        
        
    }
}

