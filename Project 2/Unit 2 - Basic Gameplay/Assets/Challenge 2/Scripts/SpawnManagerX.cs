using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        // In Random.Range, Left value is inclusive while Right Value is exclusive
        InvokeRepeating("SpawnRandomBall", startDelay, Random.Range(3, 6));
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // spawnInterval = Random.Range(10, 20);
        // Generate random ball index
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
