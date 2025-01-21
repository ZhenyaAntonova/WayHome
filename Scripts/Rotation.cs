using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 15.0f;
    [SerializeField] PlanetSystemManager sceneManager;
    void FixedUpdate()
    {
        if(sceneManager != null)
        {
            if (sceneManager.gameIsOn)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
