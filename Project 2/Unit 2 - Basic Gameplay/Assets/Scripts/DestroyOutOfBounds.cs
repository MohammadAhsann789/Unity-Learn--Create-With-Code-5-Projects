using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float frontBoundForProjectile = 30f;
    private float lowerBoundForFrontAnimals = -10f;
    private float sideBoundForSideAnimals = 20.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.Lives <= 0)
        {
            // EditorApplication.isPlaying = false;
        }

        if (transform.position.z > frontBoundForProjectile)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBoundForFrontAnimals)
        {
            Debug.Log("Front Side Game Over!");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBoundForSideAnimals)
        {
            Debug.Log("Right Side Game Over!");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBoundForSideAnimals)
        {
            Debug.Log("Left Side Game Over!");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }

    }
}
