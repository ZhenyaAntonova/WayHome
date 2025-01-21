using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovemet : MonoBehaviour
{
    float speed = 5.0f;
    CharacterController controller;
    public PlanetSystemManager sceneManager;
    public AudioSource damageSound;

    float upperBound = 30f;
    float lowerBound = -2f;
    float leftBound = -7f;
    float rightBound = 7f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(sceneManager.gameIsOn)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            controller.enabled = true;
            controller.Move(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        }

        ConstrainPlayerPosition();
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.y > upperBound)
        {
            sceneManager.NextScene();
            //transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }

        if (transform.position.y < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(sceneManager.gameIsOn)
        {
            sceneManager.lives--;
            damageSound.PlayOneShot(damageSound.clip);
        }
    }
}
