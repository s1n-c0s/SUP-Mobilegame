using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public TextMeshProUGUI objectNameText;

    void Start()
    {
        // choose a random object from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject objectToActivate = objectsToSpawn[randomIndex];

        // get the name of the object to activate
        string objectName = objectToActivate.name;

        // set the text property of the objectNameText object
        objectNameText.text = objectName;
        Debug.Log(objectNameText.text);

        // toggle the active state of the chosen object
        objectToActivate.SetActive(true);
    }
}

/*void Update()
    {
        // if the spawned object is destroyed, spawn a new one inside the SpawnArea object
        if (spawnedObject == null)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];

            // get the name of the object to spawn
            string objectName = objectToSpawn.name;

            // set the text property of the objectNameText object
            objectNameText.text = "Object to spawn: " + objectName;

            spawnedObject = Instantiate(objectToSpawn, spawnArea).transform;
        }
    }
}

*/