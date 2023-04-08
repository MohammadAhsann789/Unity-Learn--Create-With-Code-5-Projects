using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup

    public ParticleSystem smokeParticles;

    private float playerMaxRangeZ = 29f;
    private float playerMinRangeZ = -9.3f;
    private float playerRangeX = 19.2f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime); 

        if(Input.GetKey(KeyCode.Space))
        {
            if(verticalInput == 0)
            {
                verticalInput = 1;
            }
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed/3 * Time.deltaTime, ForceMode.Impulse);
            smokeParticles.Play();
        }
        KeepPlayerInbound();

        // Set powerup indicator position to beneath player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

    }

    void KeepPlayerInbound()
    {
        // Keep the player inbound when large impulse force is applied while pressing the spacebar key
        if (transform.position.z > playerMaxRangeZ)
        {
            ResetPlayerPosition(transform.position.x, playerMaxRangeZ);
        }
        if (transform.position.z < playerMinRangeZ)
        {
            ResetPlayerPosition(transform.position.x, playerMinRangeZ);
        }

        if (transform.position.x > playerRangeX)
        {
            ResetPlayerPosition(playerRangeX, transform.position.z);
        }
        if (transform.position.x < -playerRangeX)
        {
            ResetPlayerPosition(-playerRangeX, transform.position.z);
        }
    }

    void ResetPlayerPosition(float x, float z)
    {
        transform.position = new Vector3(x, 0, z);
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position; 
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}
