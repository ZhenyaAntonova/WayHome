using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float speed = 8.0f;
    public int targetNum;
    private WayHomeSceneManager sceneManager;

    Vector3 targetPos;
    Vector3 direction;

    void Start()
    {
        sceneManager = FindAnyObjectByType<WayHomeSceneManager>();

        gameObject.tag = "Obstacle";
        
        if(targetNum == 1)
        {
            targetPos = new Vector3(-1.2f, -1.8f, -8.7f);
        }
        else if(targetNum == 2)
        {
            targetPos = new Vector3(0, -1.8f, -8.7f);
        }
        else
        {
            targetPos = new Vector3(1.2f, -1.8f, -8.7f);
        }
    }

    void LateUpdate()
    {
        if(sceneManager.gameIsOn)
        {
            Move();
        }
    }

    private void Move()
    {
        direction = targetPos - transform.position;
        transform.LookAt(targetPos);

        if (direction.magnitude > 2)
        {
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            transform.position = transform.position + velocity;
        }

        if (transform.position.y <= 0.5f)
        {
            Destroy(gameObject);
            sceneManager.planetsPassed++;
            sceneManager.PlayPassedPlanetSound();
        }
    }
}
