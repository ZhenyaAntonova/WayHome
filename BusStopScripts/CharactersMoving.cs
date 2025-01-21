using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMoving : MonoBehaviour
{
    private float speed = 2.0f;
    private float borderX = 2.0f;
    public bool stopped = false;

    void FixedUpdate()
    {
        if(transform.position.x > borderX && !stopped)
        {
            transform.Translate(Vector3.right * -speed * Time.fixedDeltaTime);
        }
        else
        {
            stopped = true;
        }
    }
}
