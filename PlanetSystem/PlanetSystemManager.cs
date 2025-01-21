using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetSystemManager : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private Image[] emptyHearts;
    [SerializeField] private Image wordCloud;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverTxt;
    [SerializeField] private TMP_Text monolog;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject configMenu;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private AudioSource passedPlanetSound;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private ParticleSystem exhaustion;
    [SerializeField] private GameObject homePlanet;
    public Slider volSlider;
    public GameManager gameManager;
    public RocketMovemet rocketController;

    public int lives;
    public int maxLives = 5;
    public int planetsPassed = 0;
    public bool gameIsOn = true;
    public bool sceneEnded = false;
    public int obstaclesToAvoid = 11;
    private float wait = 4;
    private float camPosX = -5.0f;
    private float camPosY = 6.5f;
    private float camPosZ = -10.0f;
    private float camRotY = 90.0f;
    private float camRotZ = 75.0f;
    private Vector3 camPos;
    private Quaternion camRot;

    void Start()
    {
        gameIsOn = true;
        audioS = FindFirstObjectByType<Camera>().GetComponent<AudioSource>();
        audioS.volume = GameManager.volume;
        volSlider.value = GameManager.volume;

        camPos = new Vector3(camPosX, camPosY, camPosZ);
        camRot = Quaternion.Euler(0f, camRotY, camRotZ);

        if (GameManager.lives != 0)
        {
            lives = GameManager.lives;
        }
        else
        {
            lives = maxLives;
        }
        UpdateLives();

    }

    void Update()
    {
        UpdateLives();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            NextScene();
        }
    }

    void UpdateLives()
    {
        if (lives == 0)
        {
            GameOver();

            for (int i = 0; i < maxLives; i++)
            {
                emptyHearts[i].gameObject.SetActive(true);
            }
        }

        if (lives < maxLives && gameIsOn)
        {
            for (int i = (maxLives - 1); i >= lives; i--)
            {
                emptyHearts[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < lives; i++)
            {
                emptyHearts[i].gameObject.SetActive(false);
            }
        }
        else if (lives == maxLives && gameIsOn)
        {
            for (int i = 0; i < maxLives; i++)
            {
                emptyHearts[i].gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ShowMonolog()
    {
        PauseScene();
        wordCloud.gameObject.SetActive(true);
        monolog.text = "пролетев мимо " + (obstaclesToAvoid - 1).ToString() + " планет, я доберусь до моего дома";
        yield return new WaitForSeconds(wait);
        monolog.text = "эти планеты могут быть на моем пути";
        yield return new WaitForSeconds(wait);
        monolog.text = "нужно успеть вовремя от них увернуться";
        yield return new WaitForSeconds(wait);
        wordCloud.gameObject.SetActive(false);
        UnpauseScene();
    }

    void GameOver()
    {
        PauseScene();

        gameOverTxt.text = GameManager.playerName + ", вы проиграли!";
        gameOverPanel.SetActive(true);
    }

    public void Reload()
    {
        FinishScene();

        clickAudio.PlayOneShot(clickAudio.clip);
        SceneManager.LoadScene("PlanetsScene");
    }

    public void GoToMenu()
    {
        FinishScene();

        clickAudio.PlayOneShot(clickAudio.clip);
        SceneManager.LoadScene("MenuScene");
    }

    public void NextScene()
    {
        FinishScene();

        GameManager.lives = lives;
        SceneManager.LoadScene("TheWayHome");
    }

    public void OpenPauseMenu()
    {
        PauseScene();

        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(true);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void OpenConfig()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        configMenu.SetActive(true);
    }

    public void OpenControls()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        UnpauseScene();

        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(false);
        gameIsOn = true;
    }

    public void ConfVolume()
    {
        float vol = volSlider.value;
        GameManager.volume = vol;
        audioS.volume = vol;
    }

    public void FinishScene()
    {
        gameIsOn = false;
        sceneEnded = true;

        exhaustion.Stop();

        StopAllCoroutines();
    }

    public void PauseScene()
    {
        gameIsOn = false;

        exhaustion.Pause();
    }

    public void UnpauseScene()
    {
        gameIsOn = true;

        exhaustion.Play();
    }
}
