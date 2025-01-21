using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BusStopSceneManager : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private GameObject[] characters;
    [SerializeField] private GameObject bus;
    [SerializeField] private GameObject choosingPanel;
    [SerializeField] private TMP_Text chooseTxt;
    private AudioSource audioS;

    private float xBorder = -12.0f;
    private bool convoStarted = false;
    private int cloudNum = 0;
    private float timeAppear = 4.5f;

    private void Start()
    {
        audioS = FindAnyObjectByType<Camera>().GetComponent<AudioSource>();
        audioS.volume = GameManager.volume;
    }

    void Update()
    {
        if((bus.transform.position.x <= xBorder) && !(convoStarted))
        {
            for(int i = 0; i < characters.Length; i++)
            {
                characters[i].transform.Rotate(Vector3.up * 90.0f);
            }
            convoStarted = true;
            mainCam.gameObject.transform.Translate(Vector3.forward * 2.7f);
            mainCam.gameObject.transform.Translate(Vector3.left * 2.0f);

            Dialog();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Dialog()
    {
        StartCoroutine(ImageAppearance(clouds[cloudNum], timeAppear));
    }

    IEnumerator ImageAppearance(GameObject obj, float time)
    {
        cloudNum++;
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
        if(!((cloudNum + 1) > clouds.Length))
        {
            StartCoroutine(ImageAppearance(clouds[cloudNum], timeAppear));
        }
        else
        {
            for (int i = 0; i < characters.Length; i++)
            {   
                if(i == (characters.Length - 1))
                {
                    choosingPanel.SetActive(true);
                    chooseTxt.text = GameManager.playerName + chooseTxt.text;
                }

                characters[i].GetComponent<Lighting>().canChoose = true;
            }
        }
    }

    public void ChooseCharacter(Material[] materials)
    {
        GameManager.playerColor = materials;
        SceneManager.LoadScene("PlanetsScene");
    }
}
