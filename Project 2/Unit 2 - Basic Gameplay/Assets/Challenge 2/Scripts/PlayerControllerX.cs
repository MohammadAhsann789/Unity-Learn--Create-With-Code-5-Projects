using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool isTimeElapsed;

    private float spawnInterval = 3.0f;
    private void Start()
    {
        InvokeRepeating("CheckElapsedTime", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && isTimeElapsed)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            isTimeElapsed = false;
        }
    }

    void CheckElapsedTime()
    {
        isTimeElapsed = true;
    }
}
