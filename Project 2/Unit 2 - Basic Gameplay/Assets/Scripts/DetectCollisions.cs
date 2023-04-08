using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.Lives <= 0)
        {
            // EditorApplication.isPlaying = false;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        /* else if(other.CompareTag("Animal"))
        {
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            // gameManager = GameObject.Find("AnimalHunger").GetComponent<AnimalHunger>();
            Destroy(gameObject);
        } */
        else
        {
            gameManager.AddScore(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
