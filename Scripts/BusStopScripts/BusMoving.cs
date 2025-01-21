using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMoving : MonoBehaviour
{
    private float speed = 7.0f;
    private float borderX = -20.0f;

    void FixedUpdate()
    {
        if(transform.position.x > borderX)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
        }
        else
        {
            Destroy(this);
        }
    }
}
