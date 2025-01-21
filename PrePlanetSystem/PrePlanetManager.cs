using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrePlanetManager : MonoBehaviour
{
    public AudioSource audioS;
    [SerializeField] private TMP_Text monologTxt;
    [SerializeField] private Image wordCloud;

    private float wait = 4;

    void Start()
    {
        audioS = FindFirstObjectByType<Camera>().GetComponent<AudioSource>();
        audioS.volume = GameManager.volume;
        StartCoroutine(ShowMonolog());
    }

    IEnumerator ShowMonolog()
    {
        yield return new WaitForSeconds(wait);
        wordCloud.gameObject.SetActive(true);
        monologTxt.text = "на моем пути планетарная система";
        yield return new WaitForSeconds(wait);
        monologTxt.text = "нужно пролететь через нее, не задевая планеты";
        yield return new WaitForSeconds(wait);
        wordCloud.gameObject.SetActive(false);
        SceneManager.LoadScene("PlanetSystem");
    }
}
