using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject player;
    public Vector3 distanceFromPlayer;

    private void Start()
    {
        distanceFromPlayer = new Vector3(0,10,0);
    }

    void Update()
    {
        transform.localPosition = player.transform.localPosition + distanceFromPlayer;
    }
}
