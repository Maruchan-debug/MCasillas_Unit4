using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnRange = 8.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 genPos = GenerateSpawnPosition();
        Instantiate(EnemyPrefab, GenerateSpawnPosition(), EnemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float zPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, EnemyPrefab.transform.position.y, zPos);
        return spawnPos;
    }
}
