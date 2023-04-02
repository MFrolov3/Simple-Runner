using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerScript : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    //public TextMeshProUGUI gameOverText;
    public GameObject gameOverText;
    private float jumpForce = 10f;
    private float gravityModifier = 1f;
    public bool isOnGround = true;
    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameOverText.SetActive(false);
        //gameOverText = GetComponent<TextMeshProUGUI>();
        Physics.gravity *= gravityModifier;
        //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isOnGround = true;
        }
            
        else if (collision.gameObject.CompareTag("ObstaclePrefab"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverText.SetActive(true);

        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        
    }
    
}
