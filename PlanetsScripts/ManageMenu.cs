using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject configMenu;
    private PlanetsSceneManager sceneManager;
    [SerializeField] private AudioSource clickAudio;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private Slider volSlider;

    private void Start()
    {
        sceneManager = GetComponent<PlanetsSceneManager>();
        volSlider.value = GameManager.volume;
    }

    public void Reload()
    {
        sceneManager.PauseGame();
        sceneManager.sceneEnded = true;
        clickAudio.PlayOneShot(clickAudio.clip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        sceneManager.PauseGame();
        sceneManager.sceneEnded = true;
        clickAudio.PlayOneShot(clickAudio.clip);
        SceneManager.LoadScene("MenuScene");
    }

    public void OpenPauseMenu()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
        pauseMenu.SetActive(true);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
        sceneManager.PauseGame();
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
        sceneManager.audioS.volume = vol;
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
        sceneManager.UnpauseGame();
    }
}
