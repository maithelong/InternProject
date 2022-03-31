using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombie;
   public  GameObject[] SpawnPoint;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 5f;
    private float spawnTime;
    private float lastSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.FindGameObjectsWithTag("Respawn");
        UpdateSpawnTime();
    }
    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime=Random.Range(minSpawnTime,maxSpawnTime);
    }    
    void Spawn()
    {
        int point=Random.Range(0,SpawnPoint.Length);
        Instantiate(zombie, SpawnPoint[point].transform.position, Quaternion.identity);
        UpdateSpawnTime();

    }    
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime+spawnTime)
        {
            Spawn();
        }    
    }
}
