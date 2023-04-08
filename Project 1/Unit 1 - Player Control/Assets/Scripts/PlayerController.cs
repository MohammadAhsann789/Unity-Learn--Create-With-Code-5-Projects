using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float verticalInput;

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        verticalInput = Input.GetAxis("Vertical" + inputID);

        // Moves the car forward based on verticalInput
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Rotates the car based on horizontalInput
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
