using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] WayHomeSceneManager manager;
    [SerializeField] AudioSource damageSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            manager.lives--;
            damageSound.PlayOneShot(damageSound.clip);
        }
        else if(collision.gameObject.CompareTag("HomePlanet"))
        {
            manager.GetHome();
        }
    }
}
