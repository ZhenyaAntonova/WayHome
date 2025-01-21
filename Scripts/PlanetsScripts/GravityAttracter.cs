using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttracter : MonoBehaviour
{
    public float gravity = -10.0f;
    private float rotationSpeed = 50.0f;
    public Vector3 grUp;
    private void Start()
    {
        Physics.gravity = Vector3.zero;
    }
    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        grUp = gravityUp;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp)
            * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation,
            targetRotation, rotationSpeed * Time.deltaTime);
    }
}
