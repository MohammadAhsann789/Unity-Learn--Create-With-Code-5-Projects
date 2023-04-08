using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    // Front Positions
    private float frontSpawnRangeX = 15.0f; // X-Index, the point in which front animal will keep inbound   
    private float frontSpawnRangeZ = 20.0f; // Z-Index, the point from where front animals will start to appear
    
    // Side Positions
    private float sideSpawnMaxRangeZ = 16.0f; // Z-Index, the point in which side animals will keep in bound
    private float sideSpawnMinRangeZ = 3.5f; // Z-Index, the point in which side animals will keep in bound
    private float sideSpawnRangeX = -20.0f; // X-Index, the point from where side animals will start to appear


    private int startDelay = 1;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFrontAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval + 1);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval + 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFrontAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 frontSpawnPosition = new Vector3(Random.Range(-frontSpawnRangeX, frontSpawnRangeX), 0, frontSpawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], frontSpawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(sideSpawnRangeX, 0, Random.Range(sideSpawnMinRangeZ, sideSpawnMaxRangeZ));
        Vector3 spawnRotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(spawnRotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(-sideSpawnRangeX, 0, Random.Range(sideSpawnMinRangeZ, sideSpawnMaxRangeZ));
        Vector3 spawnRotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(spawnRotation));
    }
}
