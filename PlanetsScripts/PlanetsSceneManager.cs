using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetsSceneManager : MonoBehaviour
{
    public AudioSource audioS;
    [SerializeField] private GameObject player;
    [SerializeField] private Image[] emptyHearts;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverTxt;
    [SerializeField] private Camera cam;
    [SerializeField] private TMP_Text monologTxt;
    [SerializeField] private Image wordCloud;
    [SerializeField] private GravityBody gravityBody;
    [SerializeField] private Heating heatingScript;
    
    public int lives;
    public int maxLives = 5;
    public bool gameIsOn = true;
    public bool sceneEnded = false;
    private float closeRange = 2.0f;
    private void Start()
    {
        audioS = FindFirstObjectByType<Camera>().GetComponent<AudioSource>();
        audioS.volume = GameManager.volume;
        lives = maxLives;
    }

    void Update()
    {
        UpdateLives();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateLives()
    {
        if (lives == 0)
        {
            GameOver();
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

    public void PauseGame()
    {
        gameIsOn = false;
        gravityBody.StopAllCoroutines();
        heatingScript.StopAllCoroutines();
    }

    public void UnpauseGame()
    {
        gameIsOn = true;
        heatingScript.GetWarm();
    }

    public void GameOver()
    {
        PauseGame();

        gameOverTxt.text = GameManager.playerName + ", вы проиграли!";
        gameOverPanel.SetActive(true);

        for (int i = 0; i < maxLives; i++)
        {
            emptyHearts[i].gameObject.SetActive(true);
        }
    }

    public void RocketLaunch()
    {
        PauseGame();
        sceneEnded = true;
        GameManager.lives = lives;
        StopAllCoroutines();
        SceneManager.LoadScene("PrePlanetSystemScene");
    }

    public IEnumerator ShowMonolog()
    {
        PauseGame();
        wordCloud.gameObject.SetActive(true);
        cam.GetComponent<FollowCharacter>().distanceFromPlayer = new Vector3(0, 10, 1f);
        cam.orthographicSize = closeRange;
        monologTxt.text = "На ракете я доберусь до дома к ужину";
        yield return new WaitForSeconds(5);
        monologTxt.text = "Надеюсь, ничего сложного в управлении не будет";
        yield return new WaitForSeconds(5);
        RocketLaunch();
        StopAllCoroutines();
    }
}
