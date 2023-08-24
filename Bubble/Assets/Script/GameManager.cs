using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject Baloon;

    public int score = 0;
    public float second = 20;

    List<GameObject> Baloons = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI SecondTxt;
    [SerializeField]
    TextMeshProUGUI ScoreTxt;

    [SerializeField]
    GameObject popEffect;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    GameObject RestartPanel;

    [SerializeField]
    TextMeshProUGUI HighScoreText;
    [SerializeField]
    TextMeshProUGUI RestartScoreText;

    public float bSpeed=2;
    float BalloonAddSpeed=1f;

    [SerializeField]
    GameObject MouseImage;
    void Start()
    {

        LoadBaloon();
        InvokeRepeating("ShowBaloon", 0, BalloonAddSpeed);
        SecondTxt.text = second.ToString();
        
        WriteScore();
        
        StopStartTime(1);
        
        InvokeRepeating("ChangeSpeed", 0, 20f);
        InvokeRepeating("ChangeBalloonAdd", 15, 15f);
       
    }
    void ChangeBalloonAdd()
    {
        BalloonAddSpeed -= 0.1f;
        if (BalloonAddSpeed <= 0.2f)
        {
            BalloonAddSpeed = 0.2f;
        }
        CancelInvoke("ShowBaloon");
        InvokeRepeating("ShowBaloon", 0, BalloonAddSpeed);

    }
    void ChangeSpeed()
    {
        bSpeed += 1f;
        if (bSpeed >= 15f)
        {
            bSpeed = 15;
        }
    }
  
    void LoadBaloon()
    {

        for (int i = 0; i < 20; i++)
        {
            GameObject newBaloon = Instantiate(Baloon, new Vector3(Random.Range(-2.30f, 2.30f), Random.Range(-4.8f, -6.5f), 1f), Quaternion.Euler(0, 0, -180));

            Baloons.Add(newBaloon);

            newBaloon.SetActive(false);




        }

    }
    void ShowBaloon()
    {
        foreach (var b in Baloons)
        {
            if (b.activeSelf == false)
            {
                b.SetActive(true);
                b.transform.position = new Vector3(Random.Range(-2.30f, 2.30f), Random.Range(-4.8f, -6.5f), 1f);

                break;
            }
        }
    }

    void BaloonPop()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {

            if (hit.collider.CompareTag("Baloon"))
            {

                GameObject newEffect = Instantiate(popEffect, hit.transform.position, Quaternion.identity);
                newEffect.GetComponent<ParticleSystem>().startColor = hit.collider.GetComponent<MeshRenderer>().material.color;

                Destroy(newEffect, .5f);
                audioSource.Play();
                hit.collider.gameObject.SetActive(false);

                if (hit.collider.name == "Red")
                {

                    second -= 10;


                }
                else
                {
                    second += 2;
                    Score();
                }
            }

        }
    }
  
    void Score()
    {
        score += 10;
        ReturnScore();
        WriteScore();
    }
    int ReturnScore()
    {
        return score;
    }
    void Second()
    {
        second -= Time.deltaTime;
        
        WriteSecond();
        if (second <= 0)
        {
            second = 0;
            WriteSecond();
            StopStartTime(0);
            ActiveButton(RestartPanel);
        }
    }
    public void WriteSecond()
    {
        int time = (int)second;
        SecondTxt.text = time.ToString();
    }
    public void WriteScore()
    {
        if (score >= 0)
        {
            ScoreTxt.text = score.ToString();
            RestartScoreText.text = score.ToString();
        }

    }
    public void LoadScenee(int sceneBuildIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void ActiveButton(GameObject activeObject)
    {
        activeObject.SetActive(true);
    }

    public void StopStartTime(int value)
    {
        Time.timeScale = value;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale == 1)
        {
            BaloonPop();
        }
        Second();
        HighScore();
 

    }
    void HighScore()
    {
        HighScoreText.text = PlayerPrefs.GetInt("Highscore").ToString(); ;
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();

        }
    }
}


