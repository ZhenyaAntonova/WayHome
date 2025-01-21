using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private GravityAttracter attracter;
    public PlanetsSceneManager sceneMan;
    private Transform playerTransform;
    private float checkRadius = 4.0f;
    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(attracter != null)
        {
            attracter.Attract(playerTransform);
        }
    }
  
    void Update()
    {
        if(sceneMan.gameIsOn)
        {
            CheckCollisions();
        }
    }

    void CheckCollisions()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);

        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.CompareTag("Planet"))
            {
                attracter = colliders[i].gameObject.GetComponent<GravityAttracter>();
            }
        }
    }
}
