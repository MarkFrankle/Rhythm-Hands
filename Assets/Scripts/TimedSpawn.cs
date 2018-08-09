using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private GameObject spawnedObject;
    private bool spawningStopped = false;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update()
    {
        if (!stopSpawning && spawningStopped)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
            spawningStopped = false;
        }

    }

    public void SpawnObject()
    {
        //Debug.Log("Spawning: " + transform.name);
        spawnedObject = Instantiate(spawnee, transform.position, transform.rotation);
        spawnedObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
            spawningStopped = true;
        }

    }
}