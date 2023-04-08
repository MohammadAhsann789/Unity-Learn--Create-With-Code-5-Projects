using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetMainCamera = new Vector3(0, 6.5f, -13);
    private Vector3 offsetHoodCamera = new Vector3(0, 2.1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameObject.CompareTag("MainCamera"))
        {
            transform.position = player.transform.position + offsetMainCamera;
        }
        else if (gameObject.CompareTag("HoodCamera"))
        {
            transform.position = player.transform.position + offsetHoodCamera;
        }
    }
}
