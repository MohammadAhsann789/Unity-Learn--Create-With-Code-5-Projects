using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private Vector3 spawnPosition = new Vector3(35, 0, 0);

    private float startDelay = 1.5f;
    private float repeatRate = 2.0f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            int randomObstacle = Random.Range(0, obstaclesPrefab.Length);
            Instantiate(obstaclesPrefab[randomObstacle], spawnPosition,
                obstaclesPrefab[randomObstacle].transform.rotation);
        }
        /* else
        {
            CancelInvoke("SpawnObstacle");
        } */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
