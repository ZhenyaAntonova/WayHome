using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.7f;
    private float rotationSpeed = 4.0f;
    public bool isWalking = false;
    public bool isInBedroom = false;

    [SerializeField] private HomeSceneManager sceneManager;

    void Update()
    {
        if(sceneManager.gameIsOn)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput != 0)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }

            transform.localPosition += transform.forward * verticalInput * speed * Time.deltaTime;
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DoorIn"))
        {
            isInBedroom = true;
            transform.position += new Vector3(0, 0, 2);
        }
        else if (other.gameObject.CompareTag("DoorOut"))
        {
            isInBedroom = false;
            transform.position -= new Vector3(0, 0, 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bed"))
        {
            sceneManager.Ending();
        }
    }
}
