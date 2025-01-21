using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heating : MonoBehaviour
{
    float pauseTime = 4.0f;
    WaitForSeconds wait;
    Color normalColor;
    Color32 heatedColor;
    public bool isHeated;

    private PlanetsSceneManager sceneMan;
    [SerializeField] private GameObject sceneManObj;
    [SerializeField] private ParticleSystem steam;

    void Start()
    {
        wait = new WaitForSeconds(pauseTime);
        normalColor = gameObject.GetComponent<Renderer>().material.color;
        heatedColor = new Color32(210, 0, 0, 255);
        sceneMan = sceneManObj.GetComponent<PlanetsSceneManager>();

        StartCoroutine(WarmingUp());
    }

    private void Update()
    {
        if (sceneMan.sceneEnded)
        {
            StopAllCoroutines();
        }
    }

    public void GetWarm()
    {
        StartCoroutine(WarmingUp());
    }

    IEnumerator WarmingUp()
    {
        while(true)
        {
            if(sceneMan.gameIsOn)
            {
                gameObject.GetComponent<Renderer>().material.color = heatedColor;
                isHeated = true;
                steam.Play();
                yield return wait;
                gameObject.GetComponent<Renderer>().material.color = normalColor;
                isHeated = false;
                steam.Stop();
                yield return wait;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = normalColor;
            }
        }
    } 
}
