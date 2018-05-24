using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimer : MonoBehaviour
{

    public float spawnCountdown = 30.0f;

    void Update()
    {
        spawnCountdown -= Time.deltaTime;
    }
    public float spawnTime = Random.Range(5.0f, 15.0f);

    void Start()
    {
        if (spawnCountdown <= 0.0f)
        {
            Invoke("DoSpawn", spawnTime);
        }
    }

    void DoSpawn()
    {
        if (spawnCountdown <= 0.0f)
        {
            SendMessage("Spawn");
            Invoke("DoSpawn", spawnTime);
        }
    }
}
