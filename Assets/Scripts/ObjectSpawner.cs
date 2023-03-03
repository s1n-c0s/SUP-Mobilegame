using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnLocation;
    private GameObject spawnedObject;
    public Text objectNameText;

    void Start()
    {
        // choose a random object from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject objectToSpawn = objectsToSpawn[randomIndex];

        // get the name of the object to spawn
        string objectName = objectToSpawn.name;

        // set the text property of the objectNameText object
        objectNameText.text = "Object to spawn: " + objectName;
        Debug.Log(objectNameText.text);

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

            // get the name of the object to spawn
            string objectName = objectToSpawn.name;

            // set the text property of the objectNameText object
            objectNameText.text = "Object to spawn: " + objectName;

            spawnedObject = Instantiate(objectToSpawn, spawnLocation.position, Quaternion.identity);
        }
    }
}
