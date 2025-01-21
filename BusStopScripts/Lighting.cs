using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject dirLight;
    public GameObject sceneMan;
    public Material[] playerMat;

    public bool canChoose = false;

    private void Start()
    {
        playerMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials;
    }

    private void OnMouseEnter()
    {
        if(canChoose)
        {
            dirLight.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if(canChoose)
        {
            dirLight.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if(canChoose)
        {
            sceneMan.GetComponent<BusStopSceneManager>().ChooseCharacter(playerMat);
        }
    }
}
