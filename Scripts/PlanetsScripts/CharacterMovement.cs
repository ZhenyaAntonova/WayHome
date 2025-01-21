using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody playerRB;

    float speed = 8.0f;
    float horizontalInput;
    private bool isGrounded = false;
    private float jumpForce = 15.0f;
    public float boost = 0.8f;
    public bool isJumping = false;
    public bool isRunning = false;

    private PlanetsSceneManager sceneMan;
    private CharacterAnimation animScript;
    [SerializeField] private GameObject sceneManObj;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        sceneMan = sceneManObj.GetComponent<PlanetsSceneManager>();
        animScript = GetComponent<CharacterAnimation>();
    }

    private void FixedUpdate()
    {
        if(isGrounded && sceneMan.gameIsOn)
        {
            playerRB.MovePosition(playerRB.position + transform.TransformDirection(new Vector3(horizontalInput, 0, 0))
           * speed * Time.deltaTime);
        }

    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetKeyDown("space") && sceneMan.gameIsOn)
        {
            playerRB.AddRelativeForce(0, jumpForce * boost, 0, ForceMode.Impulse);
            
            isGrounded = false;
            isJumping = true;
            isRunning = false;

            animScript.PlayJumpSound();
        }

        if((horizontalInput != 0) && isGrounded && sceneMan.gameIsOn)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }
}
