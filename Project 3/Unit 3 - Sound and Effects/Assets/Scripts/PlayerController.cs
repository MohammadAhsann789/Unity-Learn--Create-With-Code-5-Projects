using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnimation;
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audioPlayer;

    public float jumpForce = 10.0f;
    public float gravityModifier = 1.0f;
    private bool isOnGround = true;
    public bool gameOver = false;

    public bool doubleJumpUsed = false;
    public float doubleJumpForce;
    public bool doubleSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimation = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtParticles.Stop();
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            audioPlayer.PlayOneShot(jumpSound, 1.0f);
            doubleJumpUsed = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameOver && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            playerRB.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnimation.Play("Running_Jump", 3, 0f);
            audioPlayer.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnimation.SetFloat("Speed_Multiplier", 5f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnimation.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explosionParticles.Play();
            dirtParticles.Stop();
            audioPlayer.PlayOneShot(crashSound, 1.0f);
        }
    }
}
