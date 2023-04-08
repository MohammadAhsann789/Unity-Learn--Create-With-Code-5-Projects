using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; } = 0;
    public int Lives { get; private set; } = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLives(int value)
    {
        Lives += value;
        if(Lives <=0)
        {
            Lives = 0;
            Debug.Log("Lives = " + Lives + ", Game Over!");
        }
        else
        {
            Debug.Log("Lives = " + Lives);
        }
    }

    public void AddScore(int value)
    {
        if(Lives > 0)
        {
            Score += value;
            Debug.Log("Score = " + Score);
        }
    }
}
