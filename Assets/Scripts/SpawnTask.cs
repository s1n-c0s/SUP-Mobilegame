using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTask : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnLocation;
    private GameObject spawnedObject;

    void Start()
    {
        // choose a random object from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject objectToSpawn = objectsToSpawn[randomIndex];

        // spawn the object at the predetermined location
        spawnedObject = Instantiate(objectToSpawn, spawnLocation.position, Quaternion.identity);
    }

    void Update()
    {
        // if the spawned object is destroyed, spawn a new one at the same location
        if (spawnedObject == null)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];
            spawnedObject = Instantiate(objectToSpawn, spawnLocation.position, Quaternion.identity);
        }
    }
}
