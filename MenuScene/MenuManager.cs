using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject confPanel;
    public GameObject namingPanel;
    public GameObject startBtn;
    public Slider volSlider;
    public TMP_InputField nameField;
    public GameManager gameManager;

    private AudioSource audioS;
    bool nameGiven = false;
    private void Start()
    {
        audioS = FindAnyObjectByType<Camera>().GetComponent<AudioSource>();

        float vol = volSlider.value;
        GameManager.volume = vol;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return) && nameGiven)
        {
            Play();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("BusStopScene");
    }
    
    public void OpenConf()
    {
        mainPanel.SetActive(false);
        confPanel.SetActive(true);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    
    public void BackToMenu()
    {
        mainPanel.SetActive(true);
        confPanel.SetActive(false);
    }
    public void ConfVolume()
    {
        float vol = volSlider.value;
        GameManager.volume = vol;
        audioS.volume = vol;
    }
    public void OpenNamingWin()
    {
        mainPanel.SetActive(false);
        namingPanel.SetActive(true);
    }
    public void Naming()
    {
        nameGiven = true;
        GameManager.playerName = nameField.text;
        startBtn.SetActive(true);     
    }
}
