using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPoints = new GameObject[5];
    GameObject spawnPoint;
    public GameObject enemy;

    public float timeToSpawn;
    float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeToSpawn) 
        {
            int chosenSpawn = Random.Range(0, SpawnPoints.Length);
            spawnPoint = SpawnPoints[chosenSpawn];
            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
