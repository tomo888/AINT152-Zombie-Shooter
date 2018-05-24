using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTimerDelay : MonoBehaviour {

    public float spawnTime = 5.0f;

    public float spawnCountdown = 30.0f;

    void Update()
    {
        spawnCountdown -= Time.deltaTime;
    }

    void Start()
    {
        Invoke("DoSpawn", spawnTime);
    }
    void DoSpawn()
    {
        SendMessage("Spawn");
        Invoke("DoSpawn", spawnTime);
    }


}
