using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody playerRB;

    float speed = 8.0f;
    float horizontalInput;
    float verticalInput;
    //private bool isGrounded = false;
    //private float jumpForce = 15.0f;
    //public float boost = 0.8f;
    //public bool isJumping = false;
    //public bool isRunning = false;

    public HomePlanetSceneManager sceneMan;
    //private CharacterAnimation animScript;
    private Transform playerTransform;
    public GravityAttracter attracter;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //animScript = GetComponent<CharacterAnimation>();
        playerTransform = GetComponent<Transform>();
        //playerRB.centerOfMass.Set(playerRB.centerOfMass.x,
        //    playerRB.centerOfMass.y - 0.2f, playerRB.centerOfMass.z);
    }

    private void FixedUpdate()
    {
        attracter.Attract(playerTransform);
        //if (isGrounded && sceneMan.gameIsOn)
        //{
        playerRB.MovePosition(playerRB.position + transform.TransformDirection(new Vector3(0, 0, verticalInput))
           * speed * Time.deltaTime);
        //}
        
        transform.Rotate(Vector3.up * 0.5f * horizontalInput);
        //transform.up = -(attracter.grUp).normalized;
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //if (isGrounded && Input.GetKeyDown("space"))// && sceneMan.gameIsOn)
        //{
        //    playerRB.AddRelativeForce(0, jumpForce * boost, 0, ForceMode.Impulse);

        //    isGrounded = false;
        //    isJumping = true;
        //    isRunning = false;

        //    animScript.PlayJumpSound();
        //}

        //if ((horizontalInput != 0) && isGrounded) //&& sceneMan.gameIsOn)
        //{
        //    isRunning = true;
        //}
        //else
        //{
        //    isRunning = false;
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Planet"))
    //    {
    //        isGrounded = true;
    //        isJumping = false;
    //    }
    //}
}
