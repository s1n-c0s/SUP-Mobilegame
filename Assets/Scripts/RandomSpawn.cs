using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn: MonoBehaviour
{
    public GameObject[] Task;
    public Vector3 spawnValues , center, size;
    public float spawnWait, spawnMostWait, spawnLeasWait;
    public int startWait,taskSpawned = 0,maxTask;
    public bool stop;

    int randTask;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        if (maxTask <= taskSpawned)
        {
            stop = true;
        }
        else
        {
            stop = false;
        }

        spawnWait = Random.Range(spawnLeasWait, spawnMostWait);

    }

    /*public void SpawnArea()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
   
    }*/

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(spawnWait);
        
        while (!stop)
        {
            taskSpawned++;
            randTask = Random.Range(0 , 2);
            Vector3 spawnPositon = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z)); //maybe
            Instantiate(Task[randTask], spawnPositon + transform.position, gameObject.transform.rotation);//maybe
            //Instantiate(enemie[randEnemy], spawnPositon + transform.TransformDirection(0, 0, 0), gameObject.transform.rotation);//maybe
            yield return new WaitForSeconds(spawnWait);

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(center, size);
        Gizmos.DrawCube(transform.position, spawnValues); 
    }
}
