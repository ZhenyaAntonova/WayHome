using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithTools : MonoBehaviour
{
    private CharacterMovement charMoveScript;
    private PlanetsSceneManager sceneMan;
    [SerializeField] private GameObject sceneManObj;
    [SerializeField] private AudioSource healingAudio;
    [SerializeField] private AudioSource damageAudio;
    WaitForSeconds waiting;
    float waitTime = 1.0f;

    void Start()
    {
        charMoveScript = GetComponent<CharacterMovement>();
        sceneMan = sceneManObj.GetComponent<PlanetsSceneManager>();
        waiting = new WaitForSeconds(waitTime);
    }

    private void Update()
    {
        if(sceneMan.sceneEnded)
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boost"))
        {
            healingAudio.PlayOneShot(healingAudio.clip);

            if(sceneMan.lives < sceneMan.maxLives)
            {
                sceneMan.lives++;
            }

            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageAudio.PlayOneShot(damageAudio.clip);
            sceneMan.lives--;
        }
        else if(collision.gameObject.CompareTag("Rocket"))
        {
            sceneMan.StartCoroutine("ShowMonolog");
        }
        else if (collision.gameObject.name == "Heating Planet")
        {
            Debug.Log("Collision Enter");
            StartCoroutine(DamageFromHeat(collision.gameObject));
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        StopAllCoroutines();
    }

    IEnumerator DamageFromHeat(GameObject heater)
    {
        while (true)
        {
            yield return waiting;

            if(heater.GetComponent<Heating>().isHeated)
            {
                damageAudio.PlayOneShot(damageAudio.clip);
                sceneMan.lives--;
            }
        }
    }
}
