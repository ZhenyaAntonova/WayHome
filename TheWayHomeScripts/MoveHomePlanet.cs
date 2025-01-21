using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHomePlanet : MonoBehaviour
{
    private float speed = 4.0f;
    private WayHomeSceneManager sceneManager;
    
    float startPosX = 0f;
    float startPosY = 40.0f;
    float startPosZ = -12.5f;
    public Vector3 startPos;
    Vector3 targetPos;
    Vector3 direction;

    void Start()
    {
        sceneManager = FindAnyObjectByType<WayHomeSceneManager>();

        startPos = new Vector3(startPosX, startPosY, startPosZ);
        targetPos = new Vector3(0, 5.0f, -8.7f);
    }

    void LateUpdate()
    {
        if (sceneManager.gameIsOn)
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
    }
}
