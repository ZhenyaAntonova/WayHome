using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    public float speed;
    public GameObject planetsSceneManObj;
    public GravityAttracter attracter;
    private PlanetsSceneManager planetsSceneManager;
    private Transform enemyTransform;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        enemyTransform = GetComponent<Transform>();
        planetsSceneManager = planetsSceneManObj.GetComponent<PlanetsSceneManager>();
    }

    void FixedUpdate()
    {
        if(planetsSceneManager.gameIsOn)
        {
            enemyRB.MovePosition(enemyRB.position + transform.TransformDirection(new Vector3(1, 0, 1))
           * speed * Time.deltaTime);
        }

        if (attracter != null)
        {
            attracter.Attract(enemyTransform);
        }
    }
}
