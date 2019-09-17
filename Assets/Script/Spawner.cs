using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnRate = 1;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemiPrefab;
    private float timeLeftBeforeSpawn = 0;
    // Use this for initialization
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeLeftBeforeSpawn = 1 / spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        Updatesapwn();
    }
    private void Updatesapwn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn < 0)
        {
            SpawnCube();
            timeLeftBeforeSpawn = 1 / spawnRate;
        }
    }
    private void SpawnCube()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnpointRandomlySelected = spawnPoints[randomSpawnPointIndex];
        GameObject newCube = Instantiate(ennemiPrefab[Random.Range(0,2)], spawnpointRandomlySelected.GetPosition(), spawnpointRandomlySelected.transform.rotation);
    }
}
