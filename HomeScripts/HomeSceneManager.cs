using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HomeSceneManager : MonoBehaviour
{
    public bool gameIsOn = true;
    private AudioSource audioS;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject configMenu;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject wordCloud;
    [SerializeField] private TMP_Text monolog;
    [SerializeField] private Slider volSlider;
    [SerializeField] private PlayerController controller;

    WaitForSeconds wait;
    int waitTime = 4;
    string[] monologs;

    void Start()
    {
        audioS = FindFirstObjectByType<Camera>().GetComponent<AudioSource>();
        audioS.volume = GameManager.volume;
        volSlider.value = GameManager.volume;

        wait = new WaitForSeconds(waitTime);

        FirstMessage();
        StartCoroutine(NextMessage());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsOn = false;
            Application.Quit();
        }
    }

    void FirstMessage()
    {
        monologs = new string[2]{(GameManager.playerName + ", спасибо за то, что привели меня домой"),
            "но посадка оставляет желать лучшего"};
        StartCoroutine(ShowMonolog(monologs, monologs.Length));
    }

    IEnumerator NextMessage()
    {
        yield return new WaitForSeconds((waitTime * 5));
        if (controller.isInBedroom)
        {
            monologs = new string[1] { "мне пора в постель" };
            StartCoroutine(ShowMonolog(monologs, monologs.Length));
        }
        else
        {
            monologs = new string[2] { "мне пора спать", "спальня в другой комнате" };
            StartCoroutine(ShowMonolog(monologs, monologs.Length));
        }
    }

    IEnumerator LastMessage()
    {
        gameIsOn = false;
        monologs = new string[2] { ("спокойной ночи, " + GameManager.playerName), "больше я не буду опаздывать на автобус"};
        StartCoroutine(ShowMonolog(monologs, monologs.Length));
        yield return new WaitForSeconds((waitTime * monologs.Length));
        gameIsOn = false;
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator ShowMonolog(string[] monologTxt, int times)
    {
        wordCloud.SetActive(true);
        for(int i = 0; i < times; i++)
        {
            monolog.text = monologTxt[i];
            yield return wait;
        }
        wordCloud.SetActive(false);
    }

    public void Ending()
    {
        StopAllCoroutines();
        StartCoroutine(LastMessage());
    }

    public void GoToMainMenu()
    {
        gameIsOn = false;
        clickAudio.PlayOneShot(clickAudio.clip);
        SceneManager.LoadScene("MenuScene");
    }

    public void OpenPauseMenu()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(true);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
        gameIsOn = false;
    }

    public void OpenConfig()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        configMenu.SetActive(true);
    }

    public void ConfVolume()
    {
        float vol = volSlider.value;
        GameManager.volume = vol;
        audioS.volume = vol;
    }

    public void OpenControls()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        gameIsOn = true;
    }
}
