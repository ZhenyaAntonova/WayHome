using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 2.0f;
    float forwardSpeed = 1.0f;
    float horizontalInput;
    float xBorder = 1.3f;

    [SerializeField] WayHomeSceneManager sceneManager;
    Vector3 direction;
    Vector3 targetPos;

    private void Start()
    {
        targetPos = new Vector3(0f, 8.0f, -10.8f);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(sceneManager.gameIsOn)
        {
            Move();
        }
        
        ConstrainPosition();
    }

    void Move()
    {
        transform.localPosition += new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
    }

    void ConstrainPosition()
    {
        if (transform.localPosition.x < -xBorder)
        {
            transform.localPosition = new Vector3(-xBorder, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.x > xBorder)
        {
            transform.localPosition = new Vector3(xBorder, transform.localPosition.y, transform.localPosition.z);
        }
    }

    public void MoveToHome()
    {
        direction = targetPos - transform.position;
        //transform.LookAt(targetPos);

        if (direction.magnitude > 2)
        {
            Vector3 velocity = direction.normalized * forwardSpeed * Time.deltaTime;
            transform.position = transform.position + velocity;
        }
    }
}
